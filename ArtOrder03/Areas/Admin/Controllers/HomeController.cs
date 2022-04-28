using Microsoft.AspNetCore.Mvc;
using ArtOrder03.Core.Constants;

namespace ArtOrder03.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            ViewData[MessageConstants.ErrorMessage] = "Влязохте в Admin Area!";
            //ViewData[MessageConstants.WarningMessage] = "Внимавай!";
            //ViewData[MessageConstants.SuccessMessage] = "Работи!";

            return View();
        }
    }
}
