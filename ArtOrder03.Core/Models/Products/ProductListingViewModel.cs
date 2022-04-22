using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtOrder03.Core.Models.Products
{
    public class ProductListingViewModel
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public string ImageUrl { get; init; }
        public decimal Price { get; init; }
        public string Category { get; set; }
    }
}
