using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Services;
using ToolBoxDeveloper.DomainContext.Domain.Dto;

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
                return await this.Autenticate(dto);

            ModelState.AddModelError("ModelOnly", "Usuário ou senha incorreto");
            return View("Index", dto);
        }
        public async Task<IActionResult> Logout()
        {
            var cookieAuthentication = CookieAuthenticationDefaults.AuthenticationScheme;

            await HttpContext.SignOutAsync(cookieAuthentication);

            return RedirectToAction("Index", "Home");
        }
        private async Task<IActionResult> Autenticate(UserDto dto)
        {
            var cookieAuthentication = CookieAuthenticationDefaults.AuthenticationScheme;
            Claim[] claims = new[]
                            {
                                new Claim(ClaimTypes.Name, dto.Email),
                                new Claim(ClaimTypes.Role, "Administrator"),
                                new Claim("Nome", dto.Email),
                            };

            ClaimsIdentity identity = new(claims, cookieAuthentication);
            ClaimsPrincipal claimsPrincipal = new(identity);

            AuthenticationProperties authProperties = new() { IsPersistent = true };

            await HttpContext
                        .SignInAsync(cookieAuthentication,claimsPrincipal,authProperties);

            return RedirectToAction("Index", "DomainContext");
        }
    }
}
