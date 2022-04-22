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
        public IEnumerable<string> Categories { get; init; }
        
        public IEnumerable<string> SearchTerm { get; init; }

        public AllProductsSorting Sorting { get; init; }

        public IEnumerable<ProductListingViewModel> Products { get; init; }
    }
}
