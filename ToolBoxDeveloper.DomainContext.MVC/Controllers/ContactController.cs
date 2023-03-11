using Microsoft.AspNetCore.Mvc;

namespace ToolBoxDeveloper.DomainContext.MVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
