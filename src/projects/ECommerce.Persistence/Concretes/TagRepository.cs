using Core.Persistence.Repositories;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Contexts;
namespace ECommerce.Persistence.Concretes;
public class TagRepository : EfRepositoryBase<Tag, Guid, BaseDbContext>, ITagRepository
{
    public TagRepository(BaseDbContext context) : base(context)
    {
    }
}
