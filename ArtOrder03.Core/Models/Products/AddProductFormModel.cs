using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtOrder03.Core.Models.Products
{
    public class AddProductFormModel
    {
        public string Name { get; set; }

        [Display(Name = "Category")]
        public string CategoryId { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }        

        public string Price { get; set; }

        public IEnumerable<ProductCategoryViewModel> ProductCategories { get; set; }
    }
}
