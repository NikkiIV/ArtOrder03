using ArtOrder03.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArtOrder03.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
           this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedCategories(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            data.Database.Migrate();
        }

        private static void SeedCategories(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Categories { Name = "Prints"},
                new Categories { Name = "Stickers"},
                new Categories { Name = "Pins"},
                new Categories { Name = "Magnets" }
            });

            data.SaveChanges();
        }

    }
}
