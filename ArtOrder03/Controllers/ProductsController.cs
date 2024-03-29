﻿using ArtOrder03.Core.Constants;
using ArtOrder03.Core.Models.Products;
using ArtOrder03.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ArtOrder03.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext data;

        public ProductsController(ApplicationDbContext data)
        {
            this.data = data;   
        }

        public IActionResult Details(int id)
        {
            var productDetails = this.data.Products
               .Where(s => s.Id == id)
               .Select(s => new ProductListingViewModel
               {
                   Id = s.Id,
                   Name = s.Name,
                   Description = s.Description,
                   ImageUrl = s.ImageUrl,
                   Price = s.Price,
                   Category = s.Category.Name

               })
               .FirstOrDefault();

            return View(productDetails);
        }

        public IActionResult Add()
        {
            var productNames = new AddProductFormModel
            {
                ProductCategories = GetProductCategories()
            };

            return View(productNames);
        }

        public IActionResult All([FromQuery]AllProductsSearchViewModel query)
        {
            var productQuery = this.data.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.OneCategory))
            {
                productQuery = productQuery.Where(r => r.Category.Name == query.OneCategory);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                productQuery = productQuery.Where(p => 
                p.Category.Name == query.SearchTerm ||
                p.Description.ToLower().Contains(query.SearchTerm.ToLower()) ||
                p.Name.ToLower().Contains(query.SearchTerm.ToLower()));
            }

            var productCategory = this.data
               .Products
               .Select(r => r.Category.Name)
               .Distinct()
               .OrderBy(r => r)
               .ToList();

            productQuery = query.Sorting switch
            {
                AllProductsSorting.DateCreatedAscending => productQuery.OrderBy(p => p.Id),
                AllProductsSorting.DateCreatedDescending => productQuery.OrderByDescending(p => p.Id)                
            };

            var totalProducts = productQuery.Count();

            var products = productQuery
                .Skip((query.CurrentPage -1) * AllProductsSearchViewModel.ProductsPerPage)
                .Take(AllProductsSearchViewModel.ProductsPerPage)
                .Where(a => a.Hidden == true)
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

            //productQuery = query.Sorting switch
            //{
            //    productQuery.DateCreatedAscending => productQuery.OrderBy(r => r.Id),
            //    productQuery.DateCreatedDescending or _ => productQuery.OrderByDescending(r => r.Id)
            //};

            query.ChooseCategory = productCategory;
            query.TotalProducts = totalProducts;
            query.Products = products;

            return View(query);
        }

        [HttpPost]
        [Authorize]
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
                CategoryId = product.CategoryId,
                Hidden = true
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

        public IActionResult Edit(int id)
        {
            var model = this.GetProductForEdit(id);

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (UpdateProduct(model))
            {
                ViewData[MessageConstants.SuccessMessage] = "Успешен запис!";
            }
            else
            {
                ViewData[MessageConstants.ErrorMessage] = "Грешка!";
            }

            return RedirectToAction(nameof(All));
        }

        public bool UpdateProduct(ProductEditViewModel model)
        {
            bool result = false;
            var product = this.data.Products.Find(model.Id);

            if (product != null)
            {
                product.Name = model.Name;
                product.ImageUrl = model.ImageUrl;
                product.Description = model.Description;
                product.Price = model.Price;

                this.data.SaveChanges();
                result = true;
            }

            return result;
        }

        public ProductEditViewModel GetProductForEdit(int id)
        {
            var product = this.data.Products.Find(id);

            return new ProductEditViewModel()
            {
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Description = product.Description,
                Price = product.Price
            };
        }

        public IActionResult Hide(int id)
        {
            var product = this.data.Products.Find(id);

            product.Hidden = !product.Hidden;

            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

    }
}
