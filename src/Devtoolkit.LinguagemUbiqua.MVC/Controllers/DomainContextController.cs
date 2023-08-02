using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Services;
using Devtoolkit.LinguagemUbiqua.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Devtoolkit.LinguagemUbiqua.MVC.Controllers
{
    [Authorize]
    public class DomainContextController : Controller
    {
        private readonly IDomainContextService _domainContextService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DomainContextController(IDomainContextService domainContextService,
            IHttpContextAccessor httpContextAccessor)
        {
            _domainContextService = domainContextService;
            _httpContextAccessor = httpContextAccessor;

        }
        private string GetNameContext()
        {
            return this._httpContextAccessor.HttpContext.User.Identity.Name;
        }

        public async Task<ActionResult> Index()
        {
            List<DomainContextDto> list = await _domainContextService.GetAll();
            return View(list);
        }

        public ActionResult Create()
        {
            return View(new DomainContextDto().SetEmail(GetNameContext()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DomainContextDto dto)
        {
            if (ModelState.IsValid)
            {
                await _domainContextService.AddOrUpdate(dto);
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("ModelOnly", "Favor preencher todos os campos");
            return RedirectToAction(nameof(Create));
        }

        public async Task<ActionResult> Edit(string id)
        {
            DomainContextDto result = await _domainContextService.Find(id);
            return View(result.SetEmail(GetNameContext()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DomainContextDto dto)
        {
            await _domainContextService.AddOrUpdate(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(string id)
        {
            await _domainContextService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
