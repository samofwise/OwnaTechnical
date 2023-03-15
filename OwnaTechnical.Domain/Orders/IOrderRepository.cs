using OwnaTechnical.Domain.Interfaces;

namespace OwnaTechnical.Domain.Orders
{
	public interface IOrderRepository: IAsyncRepository<Order>
	{
	}
}
