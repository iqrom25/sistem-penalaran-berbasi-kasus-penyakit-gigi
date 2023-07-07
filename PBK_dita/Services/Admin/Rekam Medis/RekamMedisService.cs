using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PBK_dita.Models;
using PBK_dita.Repositories;
using PBK_dita.Services.Admin.Gejala;
using PBK_dita.Services.Admin.Penyakit;

namespace PBK_dita.Services.Admin.Rekam_Medis
{
    public class RekamMedisService:IRekamMedisService
    {
        
        private readonly IRepository<RekamMedis> _repository;
        private readonly IGejalaService _gejalaService;
        private readonly IPenyakitService _penyakitService;
        private string[] includes = { "Penyakit", "ListGejala" };
        public RekamMedisService(IRepository<RekamMedis> repository, IGejalaService gejalaService, IPenyakitService penyakitService)
        {
            _repository = repository;
            _gejalaService = gejalaService;
            _penyakitService = penyakitService;
        }
        public async Task<IEnumerable<RekamMedis>> GetAll()
        {
            try
            {
                var listRekamMedis = await _repository.FindAll(includes);
                //buat order kode gejala doang biar bagus
                var rekamMedisEnumerable = listRekamMedis.ToList();
                
                for (int i=0; i<rekamMedisEnumerable.Count();i++)
                {
                    rekamMedisEnumerable[i].ListGejala = rekamMedisEnumerable[i].ListGejala.OrderBy(gejala => gejala.KodeGejala).ToList();
                }
                return rekamMedisEnumerable.OrderByDescending(rekamMedis => rekamMedis.TanggalInput);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<CreateEditRekamMedis> GetById(int id)
        {
            try
            {
                var listRekamMedis = await GetAll();
                var rekamMedis = listRekamMedis.FirstOrDefault(rekamMedis => rekamMedis.Id == id);
                if (rekamMedis is null) return null;

                var listIdGejala = rekamMedis.ListGejala.Select(gejala => gejala.Id).ToArray();
                var editModel = new CreateEditRekamMedis()
                {
                    Id = rekamMedis.Id,
                    IdPenyakit = rekamMedis.Penyakit.Id,
                    ListIdGejala = listIdGejala
                };

                return editModel;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<RekamMedis> Update(CreateEditRekamMedis rekamMedis)
        {
            try
            {
                var listGejala = await _gejalaService.GetAll();
                var existingRekamMedis = await _repository.FindBy(obj=>obj.Id == rekamMedis.Id,includes);
                
                
                //clear table GejalaRekamMedis dulu buat hindarin issue duplicate PK
                existingRekamMedis.ListGejala.Clear();
                _repository.detach(existingRekamMedis);
                await _repository.Update(existingRekamMedis);
                
                var updatedRekamMedis = existingRekamMedis with
                {
                    Penyakit = await _penyakitService.GetById(rekamMedis.IdPenyakit),
                    ListGejala = listGejala.Where(gejala => rekamMedis.ListIdGejala.Contains(gejala.Id)).ToList()
                };
                
                //buat ngehindarin issue double tracking
                _repository.detach(existingRekamMedis);
                
                return await _repository.Update(updatedRekamMedis);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<RekamMedis> Create(CreateEditRekamMedis rekamMedis)
        {
            
            try
            {
                var listGejala = await _gejalaService.GetAll();
                RekamMedis newRekamMedis = new()
                {
                    TanggalInput = DateTimeOffset.Now,
                    Penyakit = await _penyakitService.GetById(rekamMedis.IdPenyakit),
                    ListGejala = listGejala.Where(gejala=>rekamMedis.ListIdGejala.Contains(gejala.Id)).ToList()
                };
                
                return await _repository.Save(newRekamMedis);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async  Task<RekamMedis> CreateFromRiwayat(RiwayatKonsultasi konsultasi)
        {
            try
            {
                RekamMedis newRekamMedis = new()
                {
                    TanggalInput = DateTimeOffset.Now,
                    Penyakit = await _penyakitService.GetById(konsultasi.Penyakit.Id),
                    ListGejala = konsultasi.ListGejala
                };
                
                return await _repository.Save(newRekamMedis);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<int> Delete(int id)
        {
            var rekamMedis = await GetRekamMedis(id);
            if (rekamMedis is null) return 0;
            try
            {
                await _repository.Delete(rekamMedis);
                return 1;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }
        
        public async Task<RekamMedis> GetRekamMedis(int id)
        {
            return await _repository.FindBy(rekamMedis => rekamMedis.Id == id);
        }
    }
}