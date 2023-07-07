using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using PBK_dita.Models;
using PBK_dita.Repositories;

namespace PBK_dita.Services.Auth
{
    public class AuthService:IAuthService
    {
        private readonly IRepository<Models.User> _repository;

        public AuthService(IRepository<Models.User> repository)
        {
            _repository = repository;
        }
        
        public async Task<bool> Login(HttpContext httpContext, LoginModel user)
        {
            var findedUser = await _repository.FindBy((obj) => obj.Email == user.Email.ToLower());
            
            if(findedUser is null) return false;

            var isVerified = BCrypt.Net.BCrypt.Verify(user.Password, findedUser.Password);
            
            if (!isVerified) return false;
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, findedUser.Nama),
                new Claim(ClaimTypes.Email, findedUser.Email),
                new Claim("Age",findedUser.Umur.ToString()),
                new Claim(ClaimTypes.Gender,findedUser.JenisKelamin),
                new Claim(ClaimTypes.Role,findedUser.Role.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
  
            return true;

        }

        public async Task Logout(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }
    }
}