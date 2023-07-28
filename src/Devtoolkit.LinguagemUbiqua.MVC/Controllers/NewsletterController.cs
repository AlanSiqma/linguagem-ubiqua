using Microsoft.AspNetCore.Mvc;

namespace Devtoolkit.LinguagemUbiqua.MVC.Controllers
{
    public class NewsletterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
