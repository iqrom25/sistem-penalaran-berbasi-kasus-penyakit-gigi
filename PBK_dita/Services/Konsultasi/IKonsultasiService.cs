using System.Collections.Generic;
using System.Threading.Tasks;
using PBK_dita.Models;

namespace PBK_dita.Services.Konsultasi
{
    public interface IKonsultasiService
    {
        Task<HasilKonsultasi> GetResult(int[] listGejala);
    }
}