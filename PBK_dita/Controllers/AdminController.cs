using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;
using PBK_dita.Models;
using PBK_dita.Services.Admin.Dashboard;
using PBK_dita.Services.Admin.Gejala;
using PBK_dita.Services.Admin.Penyakit;
using PBK_dita.Services.Admin.Rekam_Medis;
using PBK_dita.Services.Riwayat_Konsultasi;
using PBK_dita.Services.User;
using PBK_dita.Utils;

namespace PBK_dita.Controllers
{

    
    [Authorize(Roles = "1")]
    public class AdminController : Controller
    {
        
        private readonly IPenyakitService _penyakitService;
        private readonly IGejalaService _gejalaService;
        private readonly IRekamMedisService _rekamMedisService;
        private readonly IRiwayatKonsultasiService _riwayatKonsultasiService;
        private readonly IUserService _userService;
        private readonly IDashboardService _dashboardService;
        private readonly IToastNotification _toastNotification;

        public AdminController(
            IPenyakitService penyakitService
            ,IToastNotification toastNotification
            ,IGejalaService gejalaService
            ,IRekamMedisService rekamMedisService
            ,IRiwayatKonsultasiService riwayatKonsultasiService
            ,IUserService userService,
            IDashboardService dashboardService)
        {
            _penyakitService = penyakitService;
            _gejalaService = gejalaService;
            _rekamMedisService = rekamMedisService;
            _riwayatKonsultasiService = riwayatKonsultasiService;
            _userService = userService;
            _dashboardService = dashboardService;
            _toastNotification = toastNotification;
        }
        
        // GET
        [Route("[controller]")]
        public async Task<IActionResult> Index()
        {
            ViewBag.total = await _dashboardService.GetTotal();
            return View();
        }

        #region Penyakit
        // GET
        public async Task<IActionResult> Penyakit()
        {
            var model = await _penyakitService.GetAll();
            
            if(TempData["notif"] is null) return View("Penyakit/Index",model);
                
            var notif = JsonConvert.DeserializeObject<NotifHelper>(TempData["notif"].ToString());
            
            switch (notif.Type)
            {
                case true:
                    _toastNotification.AddSuccessToastMessage(notif.Message);
                    break;
                case false when notif.Message is not null:
                    _toastNotification.AddErrorToastMessage(notif.Message);
                    break;
            }
            
            return View("Penyakit/Index",model);
        }

        public IActionResult TambahPenyakit()
        {
            return View("Penyakit/TambahPenyakit");
        }
        
        [HttpPost]
        public async Task<IActionResult> TambahPenyakit(Penyakit penyakit)
        {
            if(!ModelState.IsValid) return View("Penyakit/TambahPenyakit",penyakit);

            var isDuplicateCode = await _penyakitService.IsDuplicateCode(penyakit.KodePenyakit);

            if (isDuplicateCode)
            {
                ModelState.AddModelError("KodePenyakit","Kode Penyakit must be unique");
                return View("Penyakit/TambahPenyakit", penyakit);
            }

            var savedPenyakit = await _penyakitService.Create(penyakit);

            if (savedPenyakit is null)
            {
                TempData["notif"] = JsonConvert.SerializeObject(new NotifHelper()
                {
                    Type = false,
                    Message = NotifMessage.AddFailed
                });
                return RedirectToAction("Penyakit");
            }

            TempData["notif"] = JsonConvert.SerializeObject(new NotifHelper()
            {
                Type = true,
                Message = NotifMessage.AddSuccess
            });
            return RedirectToAction("Penyakit");
        }
        
        public async Task<IActionResult> EditPenyakit(int id)
        {
            
            var model = await _penyakitService.GetById(id);
            
            if (model is not null) return View("Penyakit/EditPenyakit",model);
            
            TempData["notif"] = JsonConvert.SerializeObject(new NotifHelper()
            {
                Type = false,
                Message = NotifMessage.NotExist
            });   
            return View("Penyakit/Index");
        }
        
        [HttpPost]
        public async Task<IActionResult> EditPenyakit(Penyakit penyakit, string kodeLama)
        {
            
            if (!ModelState.IsValid && penyakit.ImageFile is not null) return View("Penyakit/EditPenyakit",penyakit);
            
            var isDuplicateCode = await _penyakitService.IsDuplicateCode(penyakit.KodePenyakit,kodeLama);

            if (isDuplicateCode)
            {
                ModelState.AddModelError("KodePenyakit","Kode Penyakit must be unique");
                return View("Penyakit/EditPenyakit", penyakit);
            }
            
            var updatedPenyakit = await _penyakitService.Update(penyakit);

            if (updatedPenyakit is null)
            {
                TempData["notif"] = JsonConvert.SerializeObject(new NotifHelper()
                {
                    Type = false,
                    Message = NotifMessage.EditFailed
                });
                return RedirectToAction("Penyakit");
            }

            TempData["notif"] = JsonConvert.SerializeObject(new NotifHelper()
            {
                Type = true,
                Message = NotifMessage.EditSuccess
            });
            return RedirectToAction("Penyakit");
        }
        
        [HttpPost]
        public async Task<int> DeletePenyakit(int id)
        {

            return  await _penyakitService.Delete(id);

        }

        #endregion

        #region Gejala

        public async Task<IActionResult> Gejala()
        {
            var model = await _gejalaService.GetAll();
            
            if(TempData["notif"] is null) return View("Gejala/Index",model);
                
            var notif = JsonConvert.DeserializeObject<NotifHelper>(TempData["notif"].ToString());
            
            switch (notif.Type)
            {
                case true:
                    _toastNotification.AddSuccessToastMessage(notif.Message);
                    break;
                case false when notif.Message is not null:
                    _toastNotification.AddErrorToastMessage(notif.Message);
                    break;
            }
            
            return View("Gejala/Index",model);
        }

        public IActionResult TambahGejala()
        {
            return View("Gejala/TambahGejala");
        }
        
        [HttpPost]
        public async Task<IActionResult> TambahGejala(Gejala gejala)
        {
            if(!ModelState.IsValid) return View("Gejala/TambahGejala",gejala);

            var isduplicateCode = await _gejalaService.IsDuplicateCode(gejala.KodeGejala);

            if (isduplicateCode)
            {
                ModelState.AddModelError("KodeGejala","Kode Gejala must be unique");
                return View("Gejala/TambahGejala", gejala);
            }

            var savedGejala = await _gejalaService.Create(gejala);

            if (savedGejala is null) 
            {
                TempData["notif"] = JsonConvert.SerializeObject(new NotifHelper()
                {
                    Type = false,
                    Message = NotifMessage.AddFailed
                });
                return RedirectToAction("Gejala");
            }
            

            TempData["notif"] = JsonConvert.SerializeObject(new NotifHelper()
            {
                Type = true,
                Message = NotifMessage.AddSuccess
            });
            return RedirectToAction("Gejala");
        }
        
        public async Task<IActionResult> EditGejala(int id)
        {
            var model = await _gejalaService.GetById(id);
            
            if (model is not null) return View("Gejala/EditGejala",model);
            
            TempData["notif"] = JsonConvert.SerializeObject(new NotifHelper()
            {
                Type = false,
                Message = NotifMessage.NotExist
            });   
            return View("Gejala/Index");
        }
        
        [HttpPost]
        public async Task<IActionResult> EditGejala(Gejala gejala,string kodeLama)
        {
            
            if (!ModelState.IsValid) return View("Gejala/EditGejala",gejala);
            
            var isduplicateCode = await _gejalaService.IsDuplicateCode(gejala.KodeGejala,kodeLama);

            if (isduplicateCode)
            {
                ModelState.AddModelError("KodeGejala","Kode Gejala must be unique");
                return View("Gejala/EditGejala", gejala);
            }
            
            var updatedGejala = await _gejalaService.Update(gejala);

            if (updatedGejala is null)
            {
                TempData["notif"] = JsonConvert.SerializeObject(new NotifHelper()
                {
                    Type = false,
                    Message = NotifMessage.EditFailed
                });
                return RedirectToAction("Gejala");
            }

            TempData["notif"] = JsonConvert.SerializeObject(new NotifHelper()
            {
                Type = true,
                Message = NotifMessage.EditSuccess
            });
            return RedirectToAction("Gejala");
        }
        
        [HttpPost]
        public async Task<int> DeleteGejala(int id)
        {

            return await _gejalaService.Delete(id);

        }
        #endregion

        #region Rekam Medis

        public async Task<IActionResult> RekamMedis()
        {
            var model = await _rekamMedisService.GetAll();
            
            if(TempData["notif"] is null) return View("Rekam Medis/Index",model);
                
            var notif = JsonConvert.DeserializeObject<NotifHelper>(TempData["notif"].ToString());
            
            switch (notif.Type)
            {
                case true:
                    _toastNotification.AddSuccessToastMessage(notif.Message);
                    break;
                case false when notif.Message is not null:
                    _toastNotification.AddErrorToastMessage(notif.Message);
                    break;
            }
            
            return View("Rekam Medis/Index",model);
        }
        
        public async Task<IActionResult> TambahRekamMedis()
        {
            ViewBag.penyakit = await _penyakitService.GetAll();
            ViewBag.gejala = await _gejalaService.GetAll();

            return View("Rekam Medis/TambahRekamMedis");
        }

        [HttpPost]
        public async Task<IActionResult> TambahRekamMedis(CreateEditRekamMedis newRekamMedis,int[] ids)
        {
            ViewBag.penyakit = await _penyakitService.GetAll();
            ViewBag.gejala = await _gejalaService.GetAll();
            newRekamMedis.ListIdGejala = ids;

            
            if (newRekamMedis.IdPenyakit == 0)
            {
                ModelState.AddModelError("IdPenyakit","Please select Penyakit");
                return View("Rekam Medis/TambahRekamMedis", newRekamMedis);
            }
            
            if (ids.Length == 0)
            {
                ModelState.AddModelError("ListIdGejala","Please select Gejala minimum 1");
                return View("Rekam Medis/TambahRekamMedis", newRekamMedis);
            }
            
            var savedRekamMedis = await _rekamMedisService.Create(newRekamMedis);

            if (savedRekamMedis is null)
            {
                TempData["notif"] = JsonConvert.SerializeObject(new NotifHelper()
                {
                    Type = false,
                    Message = NotifMessage.AddFailed
                });
                return RedirectToAction("RekamMedis");
            }

            TempData["notif"] = JsonConvert.SerializeObject(new NotifHelper()
            {
                Type = true,
                Message = NotifMessage.AddSuccess
            });
            return RedirectToAction("RekamMedis");
        }
        
        public async Task<IActionResult> EditRekamMedis(int id)
        {
            ViewBag.penyakit = await _penyakitService.GetAll();
            ViewBag.gejala = await _gejalaService.GetAll();
            
            var model = await _rekamMedisService.GetById(id);
            
            if (model is not null) return View("Rekam Medis/EditRekamMedis",model);
            
            TempData["notif"] = JsonConvert.SerializeObject(new NotifHelper()
            {
                Type = false,
                Message = NotifMessage.NotExist
            });   
            return View("Rekam Medis/EditRekamMedis");
        }
        
        [HttpPost]
        public async Task<IActionResult> EditRekamMedis(CreateEditRekamMedis updatedRekamMedis,int[] ids)
        {
            ViewBag.penyakit = await _penyakitService.GetAll();
            ViewBag.gejala = await _gejalaService.GetAll();
            
            updatedRekamMedis.ListIdGejala = ids;
            
            if (updatedRekamMedis.IdPenyakit == 0)
            {
                ModelState.AddModelError("IdPenyakit","Please select Penyakit");
                return View("Rekam Medis/EditRekamMedis", updatedRekamMedis);
            }
            
            if (ids.Length == 0)
            {
                ModelState.AddModelError("ListIdGejala","Please select Gejala minimum 1");
                return View("Rekam Medis/EditRekamMedis", updatedRekamMedis);
            }
            
            var savedRekamMedis = await _rekamMedisService.Update(updatedRekamMedis);

            if (savedRekamMedis is null)
            {
                TempData["notif"] = JsonConvert.SerializeObject(new NotifHelper()
                {
                    Type = false,
                    Message = NotifMessage.EditFailed
                });
                return RedirectToAction("RekamMedis");
            }

            TempData["notif"] = JsonConvert.SerializeObject(new NotifHelper()
            {
                Type = true,
                Message = NotifMessage.EditSuccess
            });
            return RedirectToAction("RekamMedis");
        }
        
        [HttpPost]
        public async Task<int> DeleteRekamMedis(int id)
        {

            return await _rekamMedisService.Delete(id);

        }
        
        #endregion

        #region Riwayat Konsultasi

        public async Task<IActionResult> RiwayatKonsultasi()
        {
            var model = await _riwayatKonsultasiService.GetAll();
            
            if(TempData["notif"] is null) return View("Riwayat Konsultasi/Index",model);
                
            var notif = JsonConvert.DeserializeObject<NotifHelper>(TempData["notif"].ToString());
            
            switch (notif.Type)
            {
                case true:
                    _toastNotification.AddSuccessToastMessage(notif.Message);
                    break;
                case false when notif.Message is not null:
                    _toastNotification.AddErrorToastMessage(notif.Message);
                    break;
            }
            
            return View("Riwayat Konsultasi/Index",model);
        }

        [HttpPost]
        public async Task<IActionResult> AddRiwayatToDb(int id)
        {
            var isSuccess = await _riwayatKonsultasiService.AddToDb(id);
            
            if (!isSuccess)
            {
                TempData["notif"] = JsonConvert.SerializeObject(new NotifHelper()
                {
                    Type = false,
                    Message = NotifMessage.AddFailed
                });
                return RedirectToAction("RiwayatKonsultasi");
            }

            TempData["notif"] = JsonConvert.SerializeObject(new NotifHelper()
            {
                Type = true,
                Message = NotifMessage.AddSuccess
            });
            return RedirectToAction("RiwayatKonsultasi");
        }

        public async Task<IActionResult> RevisiRiwayat(int id)
        {
            var riwayat = await _riwayatKonsultasiService.GetById(id);
            RevisiModel model = new()
            {
                IdRiwayat = riwayat.Id,
                IdPenyakit = riwayat.Penyakit.Id,
                Similiarity = riwayat.Similiarity
            };
            ViewBag.penyakit = await _penyakitService.GetAll();

            return View("Riwayat Konsultasi/Revisi", model);
        }

        [HttpPost]
        public async Task<IActionResult> RevisiRiwayat(RevisiModel revisi)
        {
            ViewBag.penyakit = await _penyakitService.GetAll();
            if (!ModelState.IsValid) return View("Riwayat Konsultasi/Revisi",revisi);

            var newRiwayat = await _riwayatKonsultasiService.Revisi(revisi);
            
            if (newRiwayat is null)
            {
                TempData["notif"] = JsonConvert.SerializeObject(new NotifHelper()
                {
                    Type = false,
                    Message = NotifMessage.EditFailed
                });
                return RedirectToAction("RiwayatKonsultasi");
            }

            TempData["notif"] = JsonConvert.SerializeObject(new NotifHelper()
            {
                Type = true,
                Message = NotifMessage.EditSuccess
            });
            return RedirectToAction("RiwayatKonsultasi");
        }
        #endregion
        
        #region User

        public async Task<IActionResult> User()
        {
            var model = await _userService.GetAll();
            
            if(TempData["notif"] is null) return View("User/Index",model);
                
            var notif = JsonConvert.DeserializeObject<NotifHelper>(TempData["notif"].ToString());
            
            switch (notif.Type)
            {
                case true:
                    _toastNotification.AddSuccessToastMessage(notif.Message);
                    break;
                case false when notif.Message is not null:
                    _toastNotification.AddErrorToastMessage(notif.Message);
                    break;
            }
            
            return View("User/Index",model);
        }
        
        [HttpPost]
        public async Task<int> DeleteUser(int id)
        {

            return await _userService.Delete(id);

        }

        #endregion
       
    }
}