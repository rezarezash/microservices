using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                SeedData(scope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext dbContext)
        {
            if (!dbContext.Platforms.Any())
            {
                System.Console.WriteLine("Seeding data ...");
                dbContext.Platforms.AddRange(new Platform[] {
                    new Platform() { Name = "Dot net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Sql server", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kubernetes", Publisher = "CNCF", Cost = "Free" }
                });

                dbContext.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("We alreay have data");
            }
        }
    }
}