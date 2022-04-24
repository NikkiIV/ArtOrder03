using ArtOrder03.Infrastructure.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtOrder03.Infrastructure.Data
{
    public class Sales
    {
        [Key]
        [StringLength(64)]
        public int Id { get; set; }

        [Required]
        public DateTime? OrderDate { get; set; }

        ////----USER
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        //------

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        //----Products
        public ICollection<Products> Products { get; set; } = new List<Products>();
    }
}
