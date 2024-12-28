using Core.Security.Entities;
namespace ECommerce.Domain.Entities;
public class AppUserOperationClaim : UserOperationClaim
{
    public AppUser User { get; set; } = null!;
    public AppOperationClaim OperationClaim { get; set; } = null!;

    public AppUserOperationClaim(int userId, int operationClaimId) : base(userId, operationClaimId)
    {
    }
}