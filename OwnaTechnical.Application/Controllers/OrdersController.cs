using Microsoft.AspNetCore.Mvc;
using OwnaTechnical.Application.DTOs.Orders;
using OwnaTechnical.Application.Services;
using OwnaTechnical.Domain.Orders;

namespace OwnaTechnical.Application.Controllers
{
	[Route("orders")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly OrderService _orderService;

		public OrdersController(OrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAsync(int id)
		{
			var order = await _orderService.GetAsync(new() { Id = id });

			if (order == null)
				return NotFound();
			return Ok(order);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateOrderRequest request)
		{
			var response = await _orderService.CreateAsync(request);
			return Created($"/orders/{response.Id}", response);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] OrderStatus newStatus)
		{
			var response = await _orderService.UpdateAsync(new() { Id = id, NewStatus = newStatus });
			return Ok(response);
		}

		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
	}
}
