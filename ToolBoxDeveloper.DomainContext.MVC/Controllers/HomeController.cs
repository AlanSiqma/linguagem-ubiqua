using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using ToolBoxDeveloper.DomainContext.MVC.Models;

namespace ToolBoxDeveloper.DomainContext.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            this._logger = logger;   
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            var exceptionHandlerFeature =
                          HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            if(exceptionHandlerFeature.Error != null)
                this._logger.LogError($"Erro: {exceptionHandlerFeature.Error.Message}");

            return View(new ErrorViewModel { RequestId = requestId, Error = exceptionHandlerFeature.Error });
        }
    }
}
