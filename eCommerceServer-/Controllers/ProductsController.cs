using eCommerceServer_.Context;
using eCommerceServer_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceServer_.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class ProductsController : ControllerBase
{
	[HttpGet]
	[Authorize(AuthenticationSchemes = "Bearer")]
	public IActionResult GetAll()
	{
		ApplicationDbContext context = new();
		List<Product> products = context.Products.ToList();
		return Ok(products);
	}
}
