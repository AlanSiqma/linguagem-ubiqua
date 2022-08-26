using Microsoft.AspNetCore.Mvc;

namespace ToolBoxDeveloper.DomainContext.MVC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
