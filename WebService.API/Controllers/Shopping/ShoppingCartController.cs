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

	[HttpGet("{id:int}")]
	public async Task<ActionResult<ShoppingCart>> Get(int id)
	{
		var _item = await _context.ShoppingCarts.FindAsync(id);
		if (_item is null)
		{
			return NotFound();
		}
		return _item.WithShoppingItems(_context);
	}

	[HttpGet("GetPrice/{id:int}")]
	public async Task<ActionResult<double>> GetPrice(int id)
	{
		var _item = await _context.ShoppingCarts.FindAsync(id);
		if (_item is null)
		{
			return NotFound();
		}
		var _finalItem = _item.WithShoppingItems(_context);
		return _finalItem.GetFinalPrice();
	}
}