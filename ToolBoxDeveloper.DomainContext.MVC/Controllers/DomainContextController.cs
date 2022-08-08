using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.Domain.Contracts;
using ToolBoxDeveloper.DomainContext.Domain.Dto;

namespace ToolBoxDeveloper.DomainContext.MVC.Controllers
{
    [Authorize]
    public class DomainContextController : Controller
    {
        private readonly IDomainContextService _domainContextService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<DomainContextController> _logger;
        public DomainContextController(IDomainContextService domainContextService, 
            IHttpContextAccessor httpContextAccessor,
            ILogger<DomainContextController> logger)
        {
            this._domainContextService = domainContextService;
            this._httpContextAccessor = httpContextAccessor;
            this._logger = logger;
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
                await this._domainContextService.AddOrUpdate(dto);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Erro: {ex.Message}");
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
                this._logger.LogError($"Erro: {ex.Message}");
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
                this._logger.LogError($"Erro: {ex.Message}");
                throw;
            }
        }
    }
}
