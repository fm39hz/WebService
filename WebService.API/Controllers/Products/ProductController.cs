using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebService.API.Datas.Context;
using WebService.API.Datas.Models.Products;
using WebService.API.Service;

namespace WebService.API.Controllers.Products;

[Route("api/Products")]
[ApiController]
public class ProductController : ControllerBase
{
	private readonly DataContext _context;

	public ProductController(DataContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<ProductSet>>> GetAll()
	{
		var _products = await _context.Products.ToListAsync();
		if (_products.IsNullOrEmpty())
		{
			return NotFound();
		}
		return _products;
	}

	[HttpGet("{id:int}")]
	public async Task<ActionResult<ProductSet>> Get(int id)
	{
		var _item = await _context.Products.FindAsync(id);
		if (!ItemExists(id) || _item == null)
		{
			return NotFound();
		}
		return _item;
	}


	[HttpPut("{id:int}")]
	public async Task<IActionResult> Put(int id, ProductSet product)
	{
		var _item = (await Get(id)).Value!;
		_item.Quantity = product.Quantity;
		_context.Entry(_item).State = EntityState.Modified;
		try
		{
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException)
		{
			if (!ItemExists(id))
			{
				return NotFound();
			}
			throw;
		}
		return Ok();
	}

	private bool ItemExists(int id)
	{
		return _context.Products.ItemExists(id);
	}
}