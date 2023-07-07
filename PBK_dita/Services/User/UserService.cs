using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PBK_dita.Repositories;

namespace PBK_dita.Services.User
{
    public class UserService:IUserService
    {
        private readonly IRepository<Models.User> _repository;

        public UserService(IRepository<Models.User> repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Models.User>> GetAll()
        {
            try
            {
                return _repository.FindAll();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public Task<Models.User> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> IsDuplicateEmail(string email)
        {
            try
            {
                var existingUser = await _repository.FindBy(user => user.Email == email.ToLower());
            
                return existingUser is not null;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
            
            
        }
        

        public async Task<Models.User> GetByEmail(string email)
        {
            try
            {
                return await _repository.FindBy(user=>user.Email==email);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
           
        }

        public Task<Models.User> Update(Models.User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Models.User> Create(Models.User newUser)
        {
            
            try
            {
                var userToSave = newUser with
                {
                    Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password),
                    Email = newUser.Email.ToLower()
                };
                return await _repository.Save(userToSave);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                var user = await _repository.FindById(id);

                if (user is null) return 0;

                await _repository.Delete(user);
                return 1;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }
    }
}