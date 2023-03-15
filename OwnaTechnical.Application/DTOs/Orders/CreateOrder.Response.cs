using OwnaTechnical.Domain.Orders;

namespace OwnaTechnical.Application.DTOs.Orders
{
	public class CreateOrderResponse
	{
		public int Id { get; set; }
		public string CustomerName { get; set; }
		public string ProductName { get; set; }
		public OrderStatus Status { get; set; }
	}
}
