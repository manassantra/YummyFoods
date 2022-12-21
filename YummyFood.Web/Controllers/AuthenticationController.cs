using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyFood.Web.CommonBO;
using YummyFood.Web.Interfaces;
using YummyFood.Web.Models;

namespace YummyFood.Web.Controllers
{
    public class AuthenticationController : Controller
    {

        private readonly IAuthService _authService; 

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService; 
        }


        [Route("Login")]
        public IActionResult Login()
        {
            string token = HttpContext.Request.Cookies["yum_cId"];
            if (token == null)
            {
                return View();
            }
            return (RedirectToAction("Index", "Home"));
        }


        [HttpPost]
        public async Task<IActionResult> UserLogin(LoginBO bo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _authService.Login<ResponseMessegeBO>(bo);
                    var resp = JsonConvert.DeserializeObject<AuthResponse>(response.Result.ToString());
                    var cookieOptions = new CookieOptions();
                    cookieOptions.HttpOnly = true;
                    cookieOptions.Domain = "localhost";
                    cookieOptions.Path = "/";
                    cookieOptions.SameSite = SameSiteMode.Strict;
                    HttpContext.Response.Cookies.Append("yum_uId", resp.uId.ToString());
                    HttpContext.Response.Cookies.Append("yum_cId", resp.uToken.ToString());
                    if (response != null && response.IsSuccess)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return RedirectToAction("Login", "Authentication");
                }
            }
            return View(bo);
        }


        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("yum_cId");
            HttpContext.Response.Cookies.Delete("yum_uId");
            return RedirectToAction("Index", "Home");
        }

    }
}
