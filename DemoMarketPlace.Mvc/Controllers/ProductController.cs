using Microsoft.AspNetCore.Mvc;

namespace DemoMarketPlace.Mvc.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
