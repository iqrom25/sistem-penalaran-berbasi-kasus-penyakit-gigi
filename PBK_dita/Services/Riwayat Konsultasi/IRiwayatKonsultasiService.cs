using System.Collections.Generic;
using System.Threading.Tasks;
using PBK_dita.Models;

namespace PBK_dita.Services.Riwayat_Konsultasi
{
    public interface IRiwayatKonsultasiService
    {
        Task<IEnumerable<RiwayatKonsultasi>> GetAll();
        Task<RiwayatKonsultasi>? GetById(int id);
        Task<IEnumerable<RiwayatKonsultasi>> GetByUser(string email);
        Task<RiwayatKonsultasi>? Update(RiwayatKonsultasi riwayatToUpdate);
        Task<RiwayatKonsultasi>? Revisi(RevisiModel revisi);
        Task<bool> AddToDb(int id);
        Task<RiwayatKonsultasi> Create(HasilKonsultasi hasilKonsultasi);
        Task<bool> Delete(int id);
    }
}