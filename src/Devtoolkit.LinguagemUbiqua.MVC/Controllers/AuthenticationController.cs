using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Services;
using Devtoolkit.LinguagemUbiqua.Domain.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Devtoolkit.LinguagemUbiqua.MVC.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;
        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View(new UserDto());
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserDto dto)
        {
            if (ModelState.IsValid && await _userService.Autenticate(dto))
                return await Autenticate(dto);

            ModelState.AddModelError(string.Empty, "Usuário ou senha incorreto");
            return View("Index", dto);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        private async Task<IActionResult> Autenticate(UserDto dto)
        {
            var claims = new[]
                            {
                                new Claim(ClaimTypes.Name, dto.Email),
                                new Claim(ClaimTypes.Role, "Administrator"),
                                new Claim("Nome", dto.Email),
                            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            AuthenticationProperties authProperties = new () { IsPersistent = true };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

            return RedirectToAction("Index", "DomainContext");
        }
    }
}