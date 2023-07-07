using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PBK_dita.Models;
using PBK_dita.Services.Admin.Gejala;
using PBK_dita.Services.Admin.Penyakit;
using PBK_dita.Services.Admin.Rekam_Medis;
using PBK_dita.Services.Riwayat_Konsultasi;
using PBK_dita.Utils;

namespace PBK_dita.Services.Konsultasi
{
    public class KonsultasiService:IKonsultasiService
    {
        private readonly IRekamMedisService _rekamMedisService;
        private readonly IGejalaService _gejalaService;
        private readonly IPenyakitService _penyakitService;
        private readonly IRiwayatKonsultasiService _riwayatKonsultasiService;
        private readonly ClaimsPrincipal _user;
        
        public KonsultasiService(
            IRekamMedisService rekamMedisService
            , IGejalaService gejalaService
            ,IPenyakitService penyakitService
            ,IRiwayatKonsultasiService riwayatKonsultasiService
            ,IHttpContextAccessor accessor)
        {
            _rekamMedisService = rekamMedisService;
            _gejalaService = gejalaService;
            _penyakitService = penyakitService;
            _riwayatKonsultasiService = riwayatKonsultasiService;
            _user = accessor.HttpContext.User;
                
        }
        public async Task<HasilKonsultasi> GetResult(int[] listGejala)
        {
            var listRekamMedis = await _rekamMedisService.GetAll();
            var daftarGejala = await _gejalaService.GetAll();

            
            
            var d = Cbr.Retrieve(listRekamMedis.ToList(), listGejala);
            var sm = Cbr.Reuse(d).OrderByDescending(obj=>obj.Similiarity).ThenBy(obj=>obj.Id);
            var highestSm = sm.First();
            
            //get data untuk hasil konsultasi
            var resultPenyakit = await _penyakitService.GetById(highestSm.Id);
            var userName = _user.Claims.FirstOrDefault(claim=>claim.Type==ClaimTypes.Name).Value;
            var email = _user.Claims.FirstOrDefault(claim=>claim.Type==ClaimTypes.Email).Value;
            var age = _user.Claims.FirstOrDefault(claim=>claim.Type=="Age").Value;
            var gender = _user.Claims.FirstOrDefault(claim=>claim.Type==ClaimTypes.Gender).Value;
            HasilKonsultasi result = new()
            {    
                Nama = userName,
                Email = email,
                JenisKelamin = gender,
                Umur = int.Parse(age),
                DiagnosaPenyakit = resultPenyakit,
                ListGejala = daftarGejala.Where(gejala => listGejala.Contains(gejala.Id)).ToList(),
                Similiarity = Math.Round(highestSm.Similiarity, 2) 
            };
            
            //save to db
            await _riwayatKonsultasiService.Create(result);
            
            return result;
        }
    }
}