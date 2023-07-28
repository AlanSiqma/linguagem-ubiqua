using Microsoft.AspNetCore.Mvc;

namespace Devtoolkit.LinguagemUbiqua.MVC.Controllers
{
    public class LeanOnController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
