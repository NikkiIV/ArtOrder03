using Microsoft.AspNetCore.Mvc;

namespace ArtOrder03.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
