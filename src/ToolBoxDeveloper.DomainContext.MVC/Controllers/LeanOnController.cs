using Microsoft.AspNetCore.Mvc;

namespace ToolBoxDeveloper.DomainContext.MVC.Controllers
{
    public class LeanOnController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
