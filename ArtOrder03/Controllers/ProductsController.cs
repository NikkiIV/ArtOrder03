using ArtOrder03.Core.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace ArtOrder03.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddProductFormModel product)
        {
            return View();
        }
    }
}
