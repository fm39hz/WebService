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

	[HttpPut]
	public async Task<ActionResult> Put(ShoppingItem item)
	{
		_context.Update(item with
		{
			Target = await _context.Products.FindAsync(item.ProductId) ?? throw new InvalidOperationException()
		});
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
		_context.ShoppingItems.Add(item);
		await _context.SaveChangesAsync();
		return CreatedAtAction("Get", new { id = item.Id }, item);
	}

	private bool ItemExists(int id)
	{
		return _context.ShoppingItems.ItemExists(id);
	}
}