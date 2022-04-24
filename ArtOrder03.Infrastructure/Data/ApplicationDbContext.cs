using ArtOrder03.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArtOrder03.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
			builder.Entity<Commission>()
				.HasOne(c => c.User)
				.WithMany(u => u.Commissions)
				.HasForeignKey(c => c.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<CommissionOrder>()
				.HasOne(c => c.User)
				.WithMany(u => u.CommissionOrders)
				.HasForeignKey(c => c.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Products>()
				.HasOne(c => c.Category)
				.WithMany(u => u.Products)
				.HasForeignKey(c => c.CategoryId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Sales>()
				.HasOne(c => c.User)
				.WithMany(u => u.Sales)
				.HasForeignKey(c => c.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			base.OnModelCreating(builder);
        }

        public DbSet<Commission> Commissions { get; set; }
        public DbSet<CommissionOrder> CommissionOrders { get; set; }
        public DbSet<CommissionInfo> CommissionInfos { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}