using System.ComponentModel.DataAnnotations;

namespace ArtOrder03.Infrastructure.Data
{
    public class Commission
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

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
        //[Required]
        //[ForeignKey(nameof(User))]
        //public string UserId { get; set; }

        //public virtual ApplicationUser User { get; set; }

    }
}
