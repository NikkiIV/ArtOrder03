using ArtOrder03.Infrastructure.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtOrder03.Infrastructure.Data
{
    public class Products
    {
        [Key]
        [StringLength(64)]
        public int Id { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 5)]
        public string Name { get; set; }
                
        //[Column(TypeName = "decimal(18,2)")]
        //public decimal Quantity { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(250)]
        public string ImageUrl { get; set; }

        //------CATEGORY
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Categories Category { get; init; }
        //------------
               
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        //-----SALE
        [Required]
        public string SalesId { get; set; }

        [ForeignKey(nameof(Sale))]
        public Sales Sale { get; set; }
    }
}
