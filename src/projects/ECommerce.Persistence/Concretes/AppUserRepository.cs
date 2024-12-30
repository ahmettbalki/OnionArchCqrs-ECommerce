using Core.Persistence.Repositories;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Contexts;
namespace ECommerce.Persistence.Concretes;
public class AppUserRepository : EfRepositoryBase<AppUser, int, BaseDbContext>, IAppUserRepository
{
    public AppUserRepository(BaseDbContext context) : base(context)
    {
    }
}