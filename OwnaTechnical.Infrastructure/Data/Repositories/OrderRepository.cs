using Microsoft.Extensions.Caching.Memory;
using OwnaTechnical.Domain.Orders;

namespace OwnaTechnical.Infrastructure.Data.Repositories
{
	public class OrderRepository : RepositoryBase<Order>, IOrderRepository
	{
		public OrderRepository(IMemoryCache memoryCache) : base(memoryCache)
		{
		}
	}
}
