namespace OwnaTechnical.Domain.Orders
{
	public partial class Order
	{
		public void UpdateStatus(OrderStatus status)
		{
			Status = status;
		}
	}
}
