using ArtOrder03.Core.Constants;
using ArtOrder03.Core.Models.Home;
using ArtOrder03.Infrastructure.Data;
using ArtOrder03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArtOrder03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext data;

        public HomeController(ILogger<HomeController> logger,
         ApplicationDbContext _data)
        {
            _logger = logger;
            data = _data;
        }

        public IActionResult Index()
        {
            //ViewData[MessageConstant.ErrorMessage] = "Грешка!";
            //ViewData[MessageConstants.WarningMessage] = "Внимавай!";
            ViewData[MessageConstants.SuccessMessage] = "Welcome to ArtOrder!";

            var totalProducts = this.data.Products.Count();
            var totalCommission = this.data.Commissions.Count();

            return View(new IndexViewModel
            {
                TotalProducts = totalProducts,
                TotalCommissions = totalCommission
            });

            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Mistake()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}