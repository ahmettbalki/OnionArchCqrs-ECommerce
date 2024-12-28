using Core.Persistence.Repositories;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Contexts;
namespace ECommerce.Persistence.Concretes;
public class ProductTagRepository : EfRepositoryBase<ProductTag, Guid, BaseDbContext>, IProductTagRepository
{
    public ProductTagRepository(BaseDbContext context) : base(context)
    {
    }
}
