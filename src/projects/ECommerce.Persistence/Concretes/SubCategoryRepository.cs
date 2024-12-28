using Core.Persistence.Repositories;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Contexts;
namespace ECommerce.Persistence.Concretes;
public class SubCategoryRepository : EfRepositoryBase<SubCategory, int, BaseDbContext>, ISubCategory
{
    public SubCategoryRepository(BaseDbContext context) : base(context)
    {
    }
}
