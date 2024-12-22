using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace ECommerce.Persistence.Contexts;
public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions<BaseDbContext> opt): base(opt)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    DbSet<Category> Categories { get; set; }
}
