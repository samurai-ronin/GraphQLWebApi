using GraphQlWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQlWebApi.Data;
public class ProjectContext : DbContext
{
    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
}