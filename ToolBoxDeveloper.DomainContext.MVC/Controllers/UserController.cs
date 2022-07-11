using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Contracts;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Dto;

namespace ToolBoxDeveloper.DomainContext.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        public ActionResult Index()
        {
            return View(new UserDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserDto dto)
        {
            try
            {
                if(string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Password))
                    await this._userService.AddOrUpdate(dto);
                else
                    return View(dto);

                return RedirectToAction("Index", "Autentication");
            }
            catch
            {
                return View(dto);
            }
        }

        public async Task<ActionResult> Edit(string id)
        {
            UserDto result = await this._userService.Find(id);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserDto dto)
        {
            try
            {
                await this._userService.AddOrUpdate(dto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                await this._userService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
