using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebService.API.Datas.Context;
using WebService.API.Datas.Models.Shopping;
using WebService.API.Datas.Models.Users;
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

	[HttpPost("CheckOut/")]
	public async Task<ActionResult<Order>> CheckOut(ShippingInformation information)
	{
		if (!ItemExists(information.UserUId!))
		{
			return NotFound();
		}
		var _cart = _context.ShoppingCarts.First(c => c.UserUid == information.UserUId).WithShoppingItems(_context);
		var _targetItems = new List<ShoppingItem>();
		foreach (var _items in _cart.ShoppingItems.FindAll(i => i.IsSelected == 1))
		{
			_items.OrderStatus = "CheckedOut";
			_targetItems.Add(_items.WithProduct(_context.Products));
		}
		if (_targetItems.IsNullOrEmpty())
		{
			return NoContent();
		}
		var _invoice = new Invoice
		{
			UserUid = information.UserUId,
			CreatedTime = DateTime.Now
		};
		var _user = await _context.Users.FindAsync(information.UserUId);
		if (!await _context.ShippingInformations.AnyAsync(i =>
				i.UserUId == information.UserUId &&
				i.Address == information.Address &&
				i.Name == information.Name &&
				i.Gender == information.Gender &&
				i.PhoneNumber == information.PhoneNumber))
		{
			_user!.ShippingInfomations.Add(information);
			_user.Invoices.Add(_invoice);
		}
		var _order = new Order
		{
			User = _user,
			Invoice = _invoice,
			ShippingTarget = information,
			Items = _targetItems
		};
		_context.Orders.Add(_order);
		await _context.SaveChangesAsync();
		return _order;
	}

	private bool ItemExists(string uid)
	{
		return _context.ShoppingCarts.Any(c => c.UserUid == uid);
	}
}