using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PBK_dita.Repositories;

namespace PBK_dita.Services.Admin.Gejala
{
    public class GejalaService:IGejalaService
    {
        private readonly IRepository<Models.Gejala> _repository;
        
        public GejalaService(IRepository<Models.Gejala> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Models.Gejala>> GetAll()
        {
            try
            {
                var listGejala = await _repository.FindAll();
                return listGejala.OrderBy(gejala => gejala.KodeGejala);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Models.Gejala>? GetById(int id)
        {
            try
            {
                return await _repository.FindById(id);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Models.Gejala>? Update(Models.Gejala gejala)
        {
            try
            {
                var isExist = await _repository.CheckIfExist(obj => obj.Id == gejala.Id);
                if (!isExist) return null; 
                    
                var gejalaToUpdate = gejala with
                {
                    KodeGejala = gejala.KodeGejala.ToUpper()
                };

                return await _repository.Update(gejalaToUpdate);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Models.Gejala> Create(Models.Gejala newGejala)
        {
            //check duplicate kode 
            var duplicateCode = await IsDuplicateCode(newGejala.KodeGejala.ToUpper());
            if (duplicateCode) return null;
            try
            {
                var gejalaToSave = newGejala with
                {
                    KodeGejala = newGejala.KodeGejala.ToUpper()
                };
                return await _repository.Save(gejalaToSave);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<int> Delete(int id)
        {
            var gejala = await GetById(id);
            if (gejala is null) return 0;
            try
            {
                await _repository.Delete(gejala);
                return 1;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }
        
        public async Task<bool> IsDuplicateCode(string kodeGejala, string kodeLama = null)
        {
            var isDuplicate = false;
            var existingGejala = await _repository.FindBy(gejala => gejala.KodeGejala == kodeGejala.ToUpper());

            if (kodeLama is not null)
            {
                _repository.detach(existingGejala);
                isDuplicate = (existingGejala is not null && existingGejala.KodeGejala != kodeLama);
            }
            else
                isDuplicate = (existingGejala is not null);
            
            return isDuplicate;
        }
    }
}