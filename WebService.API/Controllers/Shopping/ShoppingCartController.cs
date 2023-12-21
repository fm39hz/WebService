using Microsoft.AspNetCore.Mvc;
using WebService.API.Datas.Context;
using WebService.API.Datas.Models.Shopping;
using WebService.API.Service;

namespace WebService.API.Controllers.Shopping;

[Route("api/Cart")]
[ApiController]
public class ShoppingCartController : ControllerBase
{
	private readonly DataContext _context;

	public ShoppingCartController(DataContext context)
	{
		_context = context;
	}

	[HttpGet("{uid}")]
	public ActionResult<ShoppingCart> Get(string uid)
	{
		if (!ItemExists(uid))
		{
			return NotFound();
		}
		return _context.ShoppingCarts.First(c => c.UserUid == uid).WithShoppingItems(_context);
	}

	[HttpGet("GetPrice/{uid}")]
	public ActionResult<double> GetPrice(string uid)
	{
		if (!ItemExists(uid))
		{
			return NotFound();
		}
		return _context.ShoppingCarts.First(c => c.UserUid == uid).WithShoppingItems(_context).GetFinalPrice();
	}

	private bool ItemExists(string uid)
	{
		return _context.ShoppingCarts.Any(c => c.UserUid == uid);
	}
}