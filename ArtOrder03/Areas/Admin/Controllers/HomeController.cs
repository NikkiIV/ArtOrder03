using Microsoft.AspNetCore.Mvc;

namespace ArtOrder03.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
