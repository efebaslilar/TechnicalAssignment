using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [A]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
