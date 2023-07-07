using System.Collections.Generic;
using System.Threading.Tasks;
using PBK_dita.Models;

namespace PBK_dita.Services.Admin.Rekam_Medis
{
    public interface IRekamMedisService
    {
        Task<IEnumerable<RekamMedis>> GetAll();
        Task<CreateEditRekamMedis>? GetById(int id);
        Task<RekamMedis>? Update(CreateEditRekamMedis rekamMedis);
        Task<RekamMedis> Create(CreateEditRekamMedis rekamMedis);
        
        Task<RekamMedis> CreateFromRiwayat(RiwayatKonsultasi konsultasi);
        Task<int> Delete(int id);
    }
}