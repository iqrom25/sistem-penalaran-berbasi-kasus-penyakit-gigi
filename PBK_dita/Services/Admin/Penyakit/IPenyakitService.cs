using System.Collections.Generic;
using System.Threading.Tasks;

namespace PBK_dita.Services.Admin.Penyakit
{
    public interface IPenyakitService
    {
        Task<IEnumerable<Models.Penyakit>> GetAll();
        Task<Models.Penyakit>? GetById(int id);
        Task<Models.Penyakit>? Update(Models.Penyakit penyakit);
        Task<Models.Penyakit> Create(Models.Penyakit newPenyakit);
        Task<int> Delete(int id);

        Task<bool> IsDuplicateCode(string kodePenyakit,string kodeLama = null);
    }
}