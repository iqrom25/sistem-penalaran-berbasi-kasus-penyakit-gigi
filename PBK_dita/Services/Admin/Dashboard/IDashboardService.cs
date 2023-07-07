using System.Threading.Tasks;

namespace PBK_dita.Services.Admin.Dashboard
{
    public interface IDashboardService
    {
        public Task<(int Penyakit,int Gejala, int RekamMedis, int RiwayatKonsultasi, int User)> GetTotal();
    }
}