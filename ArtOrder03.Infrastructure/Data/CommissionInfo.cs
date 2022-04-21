using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtOrder03.Infrastructure.Data
{
    public class CommissionInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Type { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        
        [Required]
        [StringLength(30)]
        public string Status { get; set; }

        public string? Comments { get; set; }

        //---CommissionOrder
        [Required]
        [ForeignKey(nameof(CommissionOrder))]
        public int CommissionOrderId { get; set; }

        [Required]
        public CommissionOrder CommissionOrder { get; set; }        
    }
}
