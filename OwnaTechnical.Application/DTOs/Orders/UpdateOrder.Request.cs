using OwnaTechnical.Domain.Orders;

namespace OwnaTechnical.Application.DTOs.Orders
{
	public class UpdateOrderRequest
	{
		public int Id { get; set; }
		public OrderStatus NewStatus { get; set; }
	}
}
