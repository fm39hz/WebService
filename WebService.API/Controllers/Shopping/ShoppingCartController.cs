using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
	public async Task<ActionResult<ShoppingCart>> Get(string uid)
	{
		var _item = await _context.ShoppingCarts.ToListAsync();
		return _item.First(c => c.UserUid == uid).WithShoppingItems(_context);
	}

	[HttpGet("GetPrice/{uid}")]
	public async Task<ActionResult<double>> GetPrice(string uid)
	{
		var _item = await _context.ShoppingCarts.ToListAsync();
		return _item.First(c => c.UserUid == uid).WithShoppingItems(_context).GetFinalPrice();
	}
}