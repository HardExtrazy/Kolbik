using Microsoft.AspNetCore.Mvc;

namespace Kolbik.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
