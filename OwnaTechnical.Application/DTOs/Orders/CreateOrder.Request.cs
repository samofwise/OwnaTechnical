using OwnaTechnical.Domain.Orders;

namespace OwnaTechnical.Application.DTOs.Orders
{
	public class CreateOrderRequest
	{
		public Customer Customer { get; set; }
		public Product Product { get; set; }

		// When you create an order I think it should create with the "Pending" as its Order Status
	}
}
