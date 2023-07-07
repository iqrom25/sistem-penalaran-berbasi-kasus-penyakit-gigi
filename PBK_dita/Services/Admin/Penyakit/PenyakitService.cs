using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using PBK_dita.Repositories;

namespace PBK_dita.Services.Admin.Penyakit
{
    public class PenyakitService:IPenyakitService
    
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IRepository<Models.Penyakit> _repository;
        
        public PenyakitService(IRepository<Models.Penyakit> repository,IWebHostEnvironment hostEnvironment)
        {
            _repository = repository;
            _hostEnvironment = hostEnvironment;
        }
        public async Task<IEnumerable<Models.Penyakit>> GetAll()
        {
            try
            {
                var listPenyakit = await _repository.FindAll();
                return listPenyakit.OrderBy(penyakit => penyakit.KodePenyakit);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Models.Penyakit>? GetById(int id)
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

        public async Task<Models.Penyakit>? Update(Models.Penyakit penyakit)
        {
            
            try
            {
                var isExist = await _repository.CheckIfExist(obj => obj.Id == penyakit.Id);
                if (!isExist) return null;
                
                var fileName = penyakit.Gambar;
                var newGambar = penyakit.ImageFile is null ? penyakit.Gambar : penyakit.ImageFile.FileName;
                if (newGambar != penyakit.Gambar)
                {
                    //hapus existing
                    var wwwRootPath = _hostEnvironment.WebRootPath;
                    var path = Path.Combine(wwwRootPath + "/img/penyakit/", fileName ?? "" /*buat jaga2 klo ada data yg dari awal blm ada gmabar*/);
                
                    if(File.Exists(path))
                        File.Delete(path);
                    
                    //add new
                    fileName = Guid.NewGuid().ToString();
                    var extension = Path.GetExtension(penyakit.ImageFile.FileName);
                    fileName += extension;
                    path = Path.Combine(wwwRootPath + "/img/penyakit/", fileName);
                    await using var fileStream = new FileStream(path,FileMode.Create);
                    await penyakit.ImageFile.CopyToAsync(fileStream);
                }
                    
                var penyakitToUpdate = penyakit with
                {
                    KodePenyakit = penyakit.KodePenyakit.ToUpper(),
                    Gambar = fileName
                };

                return await _repository.Update(penyakitToUpdate);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Models.Penyakit> Create(Models.Penyakit newPenyakit)
        {
           
            try
            {
                //Simpan gambar
                var wwwRootPath = _hostEnvironment.WebRootPath;
                var fileName = Guid.NewGuid().ToString();
                var extension = Path.GetExtension(newPenyakit.ImageFile.FileName);
                fileName += extension;
                var path = Path.Combine(wwwRootPath + "/img/penyakit/", fileName);
                await using (var fileStream = new FileStream(path,FileMode.Create))
                {
                    await newPenyakit.ImageFile.CopyToAsync(fileStream);
                }
                
                var penyakitToSave = newPenyakit with
                {
                    KodePenyakit = newPenyakit.KodePenyakit.ToUpper(),
                    Gambar = fileName
                    
                };
                return await _repository.Save(penyakitToSave);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<int> Delete(int id)
        {
            var penyakit = await GetById(id);
            if (penyakit is null) return 0;
            try
            {
                
                await _repository.Delete(penyakit);
                var wwwRootPath = _hostEnvironment.WebRootPath;
                var fileName = penyakit.Gambar;
                var path = Path.Combine(wwwRootPath + "/img/penyakit/", fileName);
                
                if(File.Exists(path))
                    File.Delete(path);
                
                return 1;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<bool> IsDuplicateCode(string kodePenyakit,string kodeLama = null)
        {
            var isDuplicate = false;
            var existingPenyakit = await _repository.FindBy(penyakit => penyakit.KodePenyakit == kodePenyakit.ToUpper());

            if (kodeLama is not null)
            {
                _repository.detach(existingPenyakit);
                isDuplicate = (existingPenyakit is not null && existingPenyakit.KodePenyakit != kodeLama);
            }
            else
                isDuplicate = (existingPenyakit is not null);
            
            return isDuplicate;
        }
    }
}