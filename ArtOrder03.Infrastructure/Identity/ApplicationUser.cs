using ArtOrder03.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ArtOrder03.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        public ICollection<Commission> Commissions { get; set; } = new List<Commission>();
        public ICollection<CommissionOrder> CommissionOrders { get; set; } = new List<CommissionOrder>();
        public ICollection<Sales> Sales { get; set; } = new List<Sales>();
    }
}
