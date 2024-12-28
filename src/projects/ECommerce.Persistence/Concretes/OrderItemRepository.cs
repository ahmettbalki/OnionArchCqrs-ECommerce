using Core.Persistence.Repositories;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Contexts;
namespace ECommerce.Persistence.Concretes;
public class OrderItemRepository : EfRepositoryBase<OrderItem, Guid, BaseDbContext>, IOrderItemRepository
{
    public OrderItemRepository(BaseDbContext context) : base(context)
    {
    }
}
