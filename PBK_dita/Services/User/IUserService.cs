using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PBK_dita.Services.User
{
    public interface IUserService
    {
        Task<IEnumerable<Models.User>> GetAll();
        Task<Models.User>? GetById(int id);
        
        Task<bool> IsDuplicateEmail(string email);
        Task<Models.User> GetByEmail(string email);
        Task<Models.User>? Update(Models.User user);
        Task<Models.User> Create(Models.User newUser);
        Task<int> Delete(int id);
    }
}