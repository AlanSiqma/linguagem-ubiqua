using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Contracts;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Dto;

namespace ToolBoxDeveloper.DomainContext.MVC.Controllers
{
    public class AutenticationController : Controller
    {
        private readonly IUserService _userService;
        public AutenticationController(IUserService userService)
        {
            this._userService = userService;           
        }
        public IActionResult Index()
        {
            return View(new UserDto());
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserDto dto)
        {

            if (ModelState.IsValid && await this._userService.Autenticate(dto))
            {
                var claims = new[]
                            {
                                new Claim(ClaimTypes.Name, dto.Email),
                                new Claim(ClaimTypes.Role, "Administrator"),
                                new Claim("Nome", dto.Email),
                            };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);


                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(identity), authProperties);

                return RedirectToAction("Index", "DomainContext");
            }
            ModelState.AddModelError("ModelOnly", "Usuário ou senha incorreto");
            return View("Index",dto);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
