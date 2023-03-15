using OwnaTechnical.Application.DTOs.Orders;
using OwnaTechnical.Domain.Orders;

namespace OwnaTechnical.Application.Services
{
	public class OrderService
	{
		private readonly IOrderRepository _orderRepository;

		public OrderService(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public async Task<GetOrderResponse?> GetAsync(GetOrderRequest request)
		{
			var order = await _orderRepository.GetAsync(o => o.Id == request.Id);

			return order == null ? null : new GetOrderResponse()
			{
				Customer = order.Customer,
				Product = order.Product,
				Status = order.Status
			};
		}

		public async Task<CreateOrderResponse> CreateAsync(CreateOrderRequest model)
		{
			var order = new Order(model.Customer, model.Product);

			var newOrder = await _orderRepository.AddAsync(order);
			//var repository = UnitOfWork.AsyncRepository<User>();
			//await repository.AddAsync(order);
			//await UnitOfWork.SaveChangesAsync();

			//TODO: Add AutoMapper
			return new()
			{
				Id = newOrder.Id,
				CustomerName = newOrder.Customer.Name,
				ProductName = newOrder.Product.Name,
				Status = newOrder.Status
			};
		}

		public async Task<UpdateOrderResponse> UpdateAsync(UpdateOrderRequest model)
		{
			var order = await _orderRepository.GetAsync(o => o.Id == model.Id);

			order.UpdateStatus(model.NewStatus);

			var updatedOrder = await _orderRepository.UpdateAsync(order);
			//var repository = UnitOfWork.AsyncRepository<User>();
			//await repository.AddAsync(order);
			//await UnitOfWork.SaveChangesAsync();

			//TODO: Add AutoMapper
			return new()
			{
				Id = updatedOrder.Id,
				CustomerName = updatedOrder.Customer.Name,
				ProductName = updatedOrder.Product.Name,
				Status = updatedOrder.Status
			};
		}

	}
}
