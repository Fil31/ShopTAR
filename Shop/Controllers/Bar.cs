using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class Bar : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
