using System.Collections.Generic;
using System.Threading.Tasks;

namespace PBK_dita.Services.Admin.Gejala
{
    public interface IGejalaService
    {
        Task<IEnumerable<Models.Gejala>> GetAll();
        Task<Models.Gejala>? GetById(int id);
        Task<Models.Gejala>? Update(Models.Gejala gejala);
        Task<Models.Gejala> Create(Models.Gejala newGejala);
        Task<int> Delete(int id);
        Task<bool> IsDuplicateCode(string kodeGejala,string kodeLama = null);
    }
}