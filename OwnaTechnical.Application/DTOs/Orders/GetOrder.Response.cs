using OwnaTechnical.Domain.Orders;

namespace OwnaTechnical.Application.DTOs.Orders
{
	public class GetOrderResponse
	{
		public Customer Customer { get; set; }
		public Product Product { get; set; }
		public OrderStatus Status { get; set; }
	}
}
