using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtOrder03.Infrastructure.Data
{
    public class CommissionOrder
    {   
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
                
        [Required]
        [StringLength(160)]
        public string Description { get; set; }

        //-----USER
        //[Required]
        //[ForeignKey(nameof(User))]
        //public string UserId { get; set; }

        //public virtual ApplicationUser User { get; set; }

        //public ICollection<CommissionInfo> CommissionInfos { get; set; } = new List<CommissionInfo>();
    }
}
