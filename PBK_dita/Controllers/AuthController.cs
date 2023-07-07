using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PBK_dita.Models;
using PBK_dita.Services.Auth;
using PBK_dita.Services.User;
using PBK_dita.Utils;

namespace PBK_dita.Controllers
{

    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService,IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }
        // GET
        public IActionResult Index()
        {
            var credential = User.Claims.ToList();
            var role = credential.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            if (role is null) return View();

            return RedirectToAction("Index", role.Value.ToString() == "0" ? "Home" : "Admin");
        }
      
        [HttpPost]
        public async Task<IActionResult> Login(LoginRegisterView userLogin)
        {
            if (!ModelState.IsValid) return View("Index",userLogin);
            
            var isLoginSuccess = await _authService.Login(HttpContext,userLogin.LoginModel);

            if (isLoginSuccess) return Redirect(userLogin.LoginModel.ReturnUrl??"/auth/index");
            
            ModelState.AddModelError("", "Invalid username or password.");
            return View("Index");

        }
        
        [HttpPost]
        public async Task<IActionResult> Register(LoginRegisterView newUser)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.mode = "register";
                return View("Index",newUser);
            }
            
            var isDuplicateEmail = await _userService.IsDuplicateEmail(newUser.User.Email);

            if (isDuplicateEmail)
            {
                ModelState.AddModelError("User.Email","Email is Already Registered");
                return View("Index",newUser);
            }
            
            try
            {
                await _userService.Create(newUser.User);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

        }
        
        public async Task<IActionResult> Logout()
        {
            await _authService.Logout(HttpContext);
            return RedirectToAction("Index","Home");

        }
        
        public IActionResult Forbidden()
        {
            return View();
        }
        
        public IActionResult NotFound()
        {
            return View();
        }
        
    }
}