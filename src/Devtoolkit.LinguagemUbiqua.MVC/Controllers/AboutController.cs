using Microsoft.AspNetCore.Mvc;

namespace Devtoolkit.LinguagemUbiqua.MVC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
