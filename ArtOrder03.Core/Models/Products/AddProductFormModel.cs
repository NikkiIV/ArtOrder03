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
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        
        [Required]
        [MinLength(3)]
        public string Description { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }
        
        [Required]
        public decimal Price { get; set; }

        public IEnumerable<ProductCategoryViewModel>? ProductCategories { get; set; }
    }
}
