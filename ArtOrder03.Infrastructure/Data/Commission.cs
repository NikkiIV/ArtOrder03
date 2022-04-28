using ArtOrder03.Infrastructure.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtOrder03.Infrastructure.Data
{
    public class Commission
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
        [StringLength(30)]
        public string Details { get; set; }

        [Required]
        [StringLength(160)]
        public string Description { get; set; }

        //-----USER
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public bool Hidden { get; set; }
    }
}
