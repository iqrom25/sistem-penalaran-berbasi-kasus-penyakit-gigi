using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PBK_dita.Models;

namespace PBK_dita.Services.Auth
{
    public interface IAuthService
    {
        Task<bool> Login(HttpContext httpContext,LoginModel user);
        Task Logout(HttpContext httpContext);
    }
}