using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebService.API.Datas.Context;
using WebService.API.Datas.Models.Shopping;
using WebService.API.Service;
using WebService.API.Service.Utils;

namespace WebService.API.Controllers.Shopping;

[Route("api/ShoppingItems")]
[ApiController]
public class ShoppingItemController : ControllerBase
{
	private readonly DataContext _context;

	public ShoppingItemController(DataContext context)
	{
		_context = context;
	}

	[HttpGet]
	public ActionResult<List<ShoppingItem>> GetAll()
	{
		return _context.ShoppingItems.WithShoppingProduct(_context).ToList();
	}

	[HttpGet("{id:int}")]
	public async Task<ActionResult<ShoppingItem>> Get(int id)
	{
		var _item = await _context.ShoppingItems.ToListAsync();
		return _item.First(c => c.Id == id).WithProduct(_context.Products);
	}

	[HttpGet("GetPrice/{id:int}")]
	public async Task<ActionResult<double>> GetFinalPrice(int id)
	{
		var _item = await _context.ShoppingItems.FindAsync(id);
		if (!ItemExists(id))
		{
			return NotFound();
		}
		return _item!.WithProduct(_context.Products).GetFinalPrice();
	}

	[HttpPut]
	public async Task<ActionResult> Put(ShoppingItem item)
	{
		item.Target ??= await _context.Products.FindAsync(item.ProductId) ?? null!;
		_context.Update(item);
		await _context.SaveChangesAsync();
		return Ok();
	}

	[HttpPost]
	public async Task<ActionResult<ShoppingItem>> Post(ShoppingItem item)
	{
		if (ItemExists(item.Id))
		{
			return Problem("Items already exists");
		}
		item.Target ??= await _context.Products.FindAsync(item.ProductId) ?? null!;
		_context.ShoppingItems.Add(item);
		await _context.SaveChangesAsync();
		return CreatedAtAction("Get", new { id = item.Id }, item);
	}

	private bool ItemExists(int id)
	{
		return _context.ShoppingItems.ItemExists(id);
	}
}