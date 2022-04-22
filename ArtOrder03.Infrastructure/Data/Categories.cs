using System.ComponentModel.DataAnnotations;

namespace ArtOrder03.Infrastructure.Data
{
    public class Categories
    {
        [Key]        
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [StringLength(250)]
        public string? ImageUrl { get; set; }

        [StringLength(260)]
        public string? Description { get; set; }

        public IEnumerable<Products> Products { get; init; } = new List<Products>();
    }
}
