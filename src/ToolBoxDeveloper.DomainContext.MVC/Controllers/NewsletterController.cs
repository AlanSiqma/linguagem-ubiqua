using Microsoft.AspNetCore.Mvc;

namespace ToolBoxDeveloper.DomainContext.MVC.Controllers
{
    public class NewsletterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
