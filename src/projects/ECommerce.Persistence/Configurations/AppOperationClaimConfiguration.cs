using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ECommerce.Persistence.Configurations;
public class AppOperationClaimConfiguration : IEntityTypeConfiguration<AppOperationClaim>
{
    public void Configure(EntityTypeBuilder<AppOperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name").IsRequired();

        builder.HasMany(c => c.UserOperationClaims)
            .WithOne(u => u.OperationClaim)
            .HasForeignKey(u => u.OperationClaimId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}