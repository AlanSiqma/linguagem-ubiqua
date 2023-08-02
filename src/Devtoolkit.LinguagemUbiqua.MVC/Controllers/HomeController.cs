using Devtoolkit.LinguagemUbiqua.MVC.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Devtoolkit.LinguagemUbiqua.MVC.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
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

            return View(new ErrorViewModel { RequestId = requestId, Error = exceptionHandlerFeature.Error });
        }
    }
}
