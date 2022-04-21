using ArtOrder03.Core.Models.Products;
using ArtOrder03.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace ArtOrder03.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext data;

        public ProductsController(ApplicationDbContext data)
        {
            this.data = data;   
        }

        public IActionResult Add()
        {
            var productNames = new AddProductFormModel
            {
                ProductCategories = GetProductCategories()
            };

            return View(productNames);
        }

        [HttpPost]
        public IActionResult Add(AddProductFormModel product)
        {
            return View();
        }

        private IEnumerable<ProductCategoryViewModel> GetProductCategories()
        {
            var result = data.Categories
                .Select(x => new ProductCategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();

            return result;
        }
    }
}
