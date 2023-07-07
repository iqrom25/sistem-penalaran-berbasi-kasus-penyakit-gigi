using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NToastNotify;
using PBK_dita.Models;
using PBK_dita.Services.Admin.Gejala;
using PBK_dita.Services.Konsultasi;
using PBK_dita.Services.Riwayat_Konsultasi;

namespace PBK_dita.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGejalaService _gejalaService;
        private readonly IKonsultasiService _konsultasiService;
        private readonly IRiwayatKonsultasiService _riwayatKonsultasiService;
        private readonly IToastNotification _toastNotification;

        public HomeController(
            ILogger<HomeController> logger
            ,IGejalaService gejalaService
            ,IKonsultasiService konsultasiService
            ,IRiwayatKonsultasiService riwayatKonsultasiService
            ,IToastNotification toastNotification)
        {
            _logger = logger;
            _gejalaService = gejalaService;
            _konsultasiService = konsultasiService;
            _riwayatKonsultasiService = riwayatKonsultasiService;
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [Authorize(Roles = "0,1")]
        public async Task<IActionResult> Konsultasi()
        {
            var listGejala = await _gejalaService.GetAll();
            
            return View(listGejala);
        }
        
        [Authorize(Roles = "0,1")]
        [HttpPost]
        public async Task<IActionResult> Konsultasi(int[] listGejala)
        {
            var daftarGejala = await _gejalaService.GetAll();
            if (listGejala.Length == 0)
            {
                ModelState.AddModelError("","Please select gejala");
                return View(daftarGejala);
            }
            
            var result = await _konsultasiService.GetResult(listGejala);
            ViewBag.result = result;
            
            return View(daftarGejala);
        }
        
        [Authorize(Roles = "0,1")]
        public async Task<IActionResult> Riwayat()
        {
            var userEmail = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email).Value;
            var riwayat = await _riwayatKonsultasiService.GetByUser(userEmail);

            if(TempData["notif"] is null)  return View(riwayat);

            var notif = JsonConvert.DeserializeObject<dynamic>(TempData["notif"].ToString());
            
            switch ((bool)notif.Type)
            {
                case true:
                    _toastNotification.AddSuccessToastMessage((string)notif.Message);
                    break;
                case false when (string)notif.Message is not null:
                    _toastNotification.AddErrorToastMessage((string)notif.Message);
                    break;
            }

            return View(riwayat);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRiwayat(int id)
        {
            var isSuccess = await _riwayatKonsultasiService.Delete(id);

            if (!isSuccess)
                TempData["notif"] = JsonConvert.SerializeObject(new
                {
                    Type = false,
                    Message = "Riwayat gagal dihapus"
                });

            
            TempData["notif"] = JsonConvert.SerializeObject(new
            {
                Type = true,
                Message = "Riwayat berhasil dihapus"
            });

            return RedirectToAction("Riwayat");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}