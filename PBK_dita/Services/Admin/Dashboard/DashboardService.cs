using System.Linq;
using System.Threading.Tasks;
using PBK_dita.Services.Admin.Gejala;
using PBK_dita.Services.Admin.Penyakit;
using PBK_dita.Services.Admin.Rekam_Medis;
using PBK_dita.Services.Riwayat_Konsultasi;
using PBK_dita.Services.User;

namespace PBK_dita.Services.Admin.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly IPenyakitService _penyakitService;
        private readonly IGejalaService _gejalaService;
        private readonly IRekamMedisService _rekamMedisService;
        private readonly IRiwayatKonsultasiService _riwayatKonsultasiService;
        private readonly IUserService _userService;
        
        public DashboardService(
            IPenyakitService penyakitService
            ,IGejalaService gejalaService
            ,IRekamMedisService rekamMedisService
            ,IRiwayatKonsultasiService riwayatKonsultasiService
            ,IUserService userService)
        {
            _penyakitService = penyakitService;
            _gejalaService = gejalaService;
            _rekamMedisService = rekamMedisService;
            _riwayatKonsultasiService = riwayatKonsultasiService;
            _userService = userService;
        }
        
        public async Task<(int Penyakit, int Gejala, int RekamMedis, int RiwayatKonsultasi, int User)> GetTotal()
        {
            var listPenyakit = await _penyakitService.GetAll();
            var totalPenyakit = listPenyakit.ToList().Count;
            
            var listGejala = await _gejalaService.GetAll();
            var totalGejala = listGejala.ToList().Count;
            
            var listRekamMedis = await _rekamMedisService.GetAll();
            var totalRekamMedis = listRekamMedis.ToList().Count;
            
            var listRiwayatKonsultasi = await _riwayatKonsultasiService.GetAll();
            var totalRiwayatKonsultasi = listRiwayatKonsultasi.ToList().Count;
            
            var listUser = await _userService.GetAll();
            var totalUser = listUser.ToList().Count;

            var result = (Penyakit: totalPenyakit, Gejala: totalGejala, RekamMedis: totalRekamMedis,
                RiwayatKonsultasi: totalRiwayatKonsultasi, User: totalUser);

            return result;

        }
    }
}