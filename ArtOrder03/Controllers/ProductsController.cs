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

        public IActionResult All(string searchTerm)
        {
            var productSearch = this.data.Products.AsQueryable();

            

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                productSearch = productSearch.Where(p => 
                p.Category.Name == searchTerm ||
                p.Description.ToLower().Contains(searchTerm.ToLower()) ||
                p.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            var products = productSearch
                .OrderByDescending(p => p.Id)
                .Select(p => new ProductListingViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,    
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Category = p.Category.Name
                })
                .ToList();

            return View(new AllProductsSearchViewModel
            {
                Products = products,
                SearchTerm = searchTerm
            });
        }

        [HttpPost]
        public IActionResult Add(AddProductFormModel product)
        {
            if (!this.data.Categories.Any(c => c.Id == product.CategoryId))
            {
                this.ModelState.AddModelError(nameof(product.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                product.ProductCategories = this.GetProductCategories();

                return View(product);
            }

            var productData = new Products
            {
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId
            };

            this.data.Products.Add(productData);
            this.data.SaveChanges();
            
            return RedirectToAction(nameof(All));
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
