using Core.Security.Entities;
namespace ECommerce.Domain.Entities;
public sealed class AppOperationClaim : OperationClaim
{
    public ICollection<AppUserOperationClaim> UserOperationClaims { get; set; } = null!;
}
