using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtOrder03.Core.Models.Products
{
    public class AllProductsSearchViewModel
    {
        public const int ProductsPerPage = 4;

        public int CurrentPage { get; init; } = 1;

        public int TotalProducts { get; set; }

        //public string Price { get; set; }
        
        public string SearchTerm { get; init; }

        public AllProductsSorting Sorting { get; init; }
        public IEnumerable<ProductListingViewModel> Products { get; set; }
    }
}
