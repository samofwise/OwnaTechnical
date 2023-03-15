namespace OwnaTechnical.Domain.Orders
{
	//TODO: Private setters
	public class Customer
	{
		public string Name { get; set; }
		// This could be a value object instead of just a string
		public string Address { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
	}
}
