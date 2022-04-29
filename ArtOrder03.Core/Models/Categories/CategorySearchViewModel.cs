using ArtOrder03.Core.Models.Products;

namespace ArtOrder03.Core.Models.Categories
{
    public class CategorySearchViewModel
    {
        public string ByName { get; set; }
        public IEnumerable<CategoryListingViewModel> ChooseCategory { get; set; }
    }
}
