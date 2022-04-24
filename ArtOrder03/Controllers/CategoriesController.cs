using ArtOrder03.Core.Models.Products;
using ArtOrder03.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace ArtOrder03.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext data;

        public CategoriesController(ApplicationDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllCategories()
        {
            var allcategories = this.data
                .Categories
                .OrderByDescending(c => c.Id)
                .Select(c => new CategoryListingViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ImageUrl = c.ImageUrl,
                    Description = c.Description
                })
                .ToList();

            return View(allcategories);
        }

        //public IActionResult OneCategory()
        //{
        //    //make a view that redirects to product of specific category
        //}
    }
}
