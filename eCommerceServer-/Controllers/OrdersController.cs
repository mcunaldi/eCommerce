using eCommerceServer_.Context;
using eCommerceServer_.Models;
using eCommerceServer_.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceServer_.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public sealed class OrdersController : ControllerBase
{
	private OrderRepository orderRepository;

	public OrdersController()
	{
		orderRepository = new();
	}

	[HttpGet]
	public IActionResult GetAll()
	{
		string userIdString = User.Claims.Single(p => p.Type == "UserId")!.Value;
		int userId = int.Parse(userIdString);

		IEnumerable<Order> orders = orderRepository.GetAllByUserId(userId);

		return Ok(orders);
	}
}
