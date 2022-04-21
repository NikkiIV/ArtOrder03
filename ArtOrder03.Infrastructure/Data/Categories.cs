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

        public IEnumerable<Products> Products { get; init; } = new List<Products>();
    }
}
