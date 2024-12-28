using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ECommerce.Persistence.Configurations;
public class AppUserOperationClaimConfiguration : IEntityTypeConfiguration<AppUserOperationClaim>
{
    public void Configure(EntityTypeBuilder<AppUserOperationClaim> builder)
    {
        builder.ToTable("UserOperationClaims").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(c => c.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();

        builder.HasOne(c => c.User)
            .WithMany(u => u.UserOperationClaims)
            .HasForeignKey(u => u.OperationClaimId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.OperationClaim)
            .WithMany(o => o.UserOperationClaims)
            .HasForeignKey(o => o.OperationClaimId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}
