using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Services;
using ToolBoxDeveloper.DomainContext.Domain.Dto;

namespace ToolBoxDeveloper.DomainContext.MVC.Controllers
{
    [Authorize]
    public class DomainContextController : Controller
    {
        private readonly IDomainContextService _domainContextService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DomainContextController(IDomainContextService domainContextService,
            IHttpContextAccessor httpContextAccessor)
        {
            this._domainContextService = domainContextService;
            this._httpContextAccessor = httpContextAccessor;

        }
        private string NameContext()
        {
            return this._httpContextAccessor.HttpContext.User.Identity.Name;
        }

        public async Task<ActionResult> Index()
        {

            List<DomainContextDto> list = await this._domainContextService.GetAll();
            return View(list);
        }

        public ActionResult Create()
        {
            return View(new DomainContextDto().SetEmail(NameContext()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DomainContextDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                    await this._domainContextService.AddOrUpdate(dto);

                ModelState.AddModelError("ModelOnly", "Favor preencher todos os campos");
                return RedirectToAction(nameof(Create));
            }
            catch (Exception ex)
            {
                string mesage = $"Exception: {ex.Message}";
                throw;
            }
        }

        public async Task<ActionResult> Edit(string id)
        {
            DomainContextDto result = await this._domainContextService.Find(id);

            return View(result.SetEmail(NameContext()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DomainContextDto dto)
        {
            try
            {
                await this._domainContextService.AddOrUpdate(dto);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                string mesage = $"Exception: {ex.Message}";

                throw;
            }
        }

        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                await this._domainContextService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                string mesage = $"Exception: {ex.Message}";
                throw;
            }
        }
    }
}
