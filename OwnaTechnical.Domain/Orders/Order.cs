using OwnaTechnical.Domain.Base;

namespace OwnaTechnical.Domain.Orders
{
	public partial class Order : BaseEntity<int>
	{
		public Order(Customer customer, Product product)
		{
			Customer = customer;
			Product = product;
			Status = OrderStatus.Pending; //When you create a product the status should be the first status "Pending"
		}

		public Customer Customer { get; private set; }

		public Product Product { get; private set; }

		public OrderStatus Status { get; private set; }

	}
}
