using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebService.API.Datas.Context;
using WebService.API.Datas.Models.Shopping;
using WebService.API.Service;
using WebService.API.Service.Utils;

namespace WebService.API.Controllers.Shopping;

[Route("api/Orders")]
[ApiController]
public class OrderController : ControllerBase
{
	private readonly DataContext _context;

	public OrderController(DataContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<List<Order>>> GetAll()
	{
		return await _context.Orders.ToListAsync();
	}

	[HttpGet("{userUid}")]
	public IEnumerable<Order> GetAllOfUser(string userUid)
	{
		if (!ItemExists(userUid))
		{
			NotFound();
		}
		foreach (var _order in _context.Orders.Where(o => o.UserUid == userUid))
		{
			yield return _order;
		}
	}

	[HttpGet("{id:int}")]
	public async Task<ActionResult<Order>> Get(int id)
	{
		if (!ItemExists(id))
		{
			NotFound();
		}
		var _order = await _context.Orders.FindAsync(id);
		return _order.WithItems(_context);
	}

	[HttpPut("{id:int}/{status:alpha}")]
	public async Task<IActionResult> Put(int id, string status)
	{
		if (!ItemExists(id))
		{
			return NotFound();
		}
		var _order = await _context.Orders.FindAsync(id);
		foreach (var _item in _order.Items)
		{
			_item.OrderStatus = status;
		}
		_context.Orders.Update(_order);
		await _context.SaveChangesAsync();
		return Ok();
	}

	private bool ItemExists(string uid)
	{
		return _context.Orders.Any(o => o.UserUid == uid);
	}

	private bool ItemExists(int id)
	{
		return _context.Orders.ItemExists(id);
	}
}