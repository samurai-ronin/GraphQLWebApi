using GraphQlWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQlWebApi.Data;
public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ProjectContext(
            serviceProvider.GetRequiredService<DbContextOptions<ProjectContext>>()))
        {
            if (context.Products.Any())
            {
                return;
            }

            context.Products.AddRange(
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "IPhone",
                    Description = "IPhone 14",
                    Price = 120000,
                    Stock = 100
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Samsung TV",
                    Description = "Smart TV",
                    Price = 400000,
                    Stock = 120
                });
            context.SaveChanges();
        }
    }
}