using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PBK_dita.Models;
using PBK_dita.Repositories;
using PBK_dita.Services.Admin.Penyakit;
using PBK_dita.Services.Admin.Rekam_Medis;
using PBK_dita.Services.User;

namespace PBK_dita.Services.Riwayat_Konsultasi
{
    public class RiwayatKonsultasiService:IRiwayatKonsultasiService
    {
        private readonly IRepository<RiwayatKonsultasi> _repository;
        private readonly IRekamMedisService _rekamMedisService;
        private readonly IPenyakitService _penyakitService;
        private readonly IUserService _userService;
        private string[] inculdes = { "User", "Penyakit", "ListGejala" };
        private double threshold = 80;

        public RiwayatKonsultasiService(
            IRepository<RiwayatKonsultasi> repository
            , IUserService userService
            ,IRekamMedisService rekamMedisService
            ,IPenyakitService penyakitService)
        {
            _repository = repository;
            _rekamMedisService = rekamMedisService;
            _penyakitService = penyakitService;
            _userService = userService;
        }
        
        public async Task<IEnumerable<RiwayatKonsultasi>> GetAll()
        {
            try
            {
                return await _repository.FindAll(inculdes);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<RiwayatKonsultasi> GetById(int id)
        {
            try
            {
                return await _repository.FindBy(riwayat=>riwayat.Id==id,inculdes);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<RiwayatKonsultasi>> GetByUser(string email)
        {
            try
            {
                return await _repository.FindByGroup(riwayat => riwayat.User.Email == email, inculdes);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
            
 
        }

        public async Task<RiwayatKonsultasi> Update(RiwayatKonsultasi riwayatToUpdate)
        {
            try
            {
                var riwayat = await GetById(riwayatToUpdate.Id);
                //clear table GejalaRiwayatKonsultasi dulu buat hindarin issue duplicate PK
                riwayat.ListGejala.Clear();
                _repository.detach(riwayat);
                await _repository.Update(riwayat);
            
                
                //buat ngehindarin issue double tracking
                _repository.detach(riwayat);
                return await _repository.Update(riwayatToUpdate);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
            
        }

        public async Task<RiwayatKonsultasi>? Revisi(RevisiModel revisi)
        {
            try
            {
                var riwayat = await GetById(revisi.IdRiwayat);

                if (riwayat is null) return null;
                var newRiwayat = riwayat with
                {
                    Penyakit = await _penyakitService.GetById(revisi.IdPenyakit),
                    Similiarity = revisi.Similiarity,
                    Status = 1
                };

                return await Update(newRiwayat);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<bool> AddToDb(int id)
        {
            try
            {
                var riwayat = await GetById(id);

                if (riwayat is null) return false;
            

                var createdRekamMedis = await _rekamMedisService.CreateFromRiwayat(riwayat);
                var success = createdRekamMedis is not null;

                if (!success) return false;


                var updatedRiwayat = riwayat with
                {
                    Status = 2
                };
                
                var update = await Update(updatedRiwayat);
                return update is not null;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
            

        }

        public async Task<RiwayatKonsultasi> Create(HasilKonsultasi hasilKonsultasi)
        {
            try
            {
                var status = hasilKonsultasi.Similiarity >= threshold ? 1 : 0;
                var newRiwayat = new RiwayatKonsultasi()
                {
                    User = await _userService.GetByEmail(hasilKonsultasi.Email),
                    Penyakit = hasilKonsultasi.DiagnosaPenyakit,
                    TanggalInput = DateTimeOffset.Now,
                    ListGejala = hasilKonsultasi.ListGejala,
                    Similiarity = hasilKonsultasi.Similiarity,
                    Status = status
                };

                return await _repository.Save(newRiwayat);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
            
        }

        public async Task<bool> Delete(int id)
        {
            try
            {           
                var riwayat = await GetById(id);

                if (riwayat is null) return false;
            
                await _repository.Delete(riwayat);

                return true;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }

        }
    }
}