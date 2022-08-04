using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Contracts;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Dto;

namespace ToolBoxDeveloper.DomainContext.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            this._userService = userService;
            this._logger = logger;
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
                if(!string.IsNullOrEmpty(dto.Email) || !string.IsNullOrEmpty(dto.Password))
                    await this._userService.AddOrUpdate(dto);
                else
                    return View(dto);

                return RedirectToAction("Index", "Autentication");
            }
            catch(Exception ex)
            {
                this._logger.LogError($"Erro: {ex.Message}");
                throw;
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
            catch(Exception ex)
            {
                this._logger.LogError($"Erro: {ex.Message}");
                throw;
            }
        }

        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                await this._userService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                this._logger.LogError($"Erro: {ex.Message}");
                throw;
            }
        }
    }
}
