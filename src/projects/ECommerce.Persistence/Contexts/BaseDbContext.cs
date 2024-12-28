using Core.Security.Entities;
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
    DbSet<Product> Products { get; set; }
    DbSet<ProductImage> ProductImages { get; set; }
    DbSet<SubCategory> SubCategories { get; set; }
    DbSet<AppUser> AppUsers { get; set; }
    DbSet<Order> Orders { get; set; }
    DbSet<OrderItem> OrderItems { get; set; }
    DbSet<Tag> Tags { get; set; }
    DbSet<ProductTag> ProductTags { get; set; }
    DbSet<OperationClaim> OperationClaims { get; set; }
    DbSet<UserOperationClaim> UserOperationClaims { get; set; }

}
