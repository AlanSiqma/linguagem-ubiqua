using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Services;
using ToolBoxDeveloper.DomainContext.Domain.Dto;

namespace ToolBoxDeveloper.DomainContext.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            return View(new UserDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserDto dto)
        {
            if (ModelState.IsValid)
                await _userService.AddOrUpdate(dto);
            else
                return View("Index", dto);

            return RedirectToAction("Index", "Authentication");
        }

        public async Task<ActionResult> Edit(string id)
        {
            UserDto result = await _userService.Find(id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserDto dto)
        {
            await _userService.AddOrUpdate(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(string id)
        {
            await _userService.Delete(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
