﻿using ArtOrder03.Core.Models.Products;
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
            
            return RedirectToAction("Index", "Home");
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
