using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebService.API.Datas.Context;
using WebService.API.Datas.Models.Products;
using WebService.API.Service;

namespace WebService.API.Controllers;

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
		if ((await _context.Products.ToListAsync()).IsNullOrEmpty())
		{
			return NotFound();
		}
		return await _context.Products.ToListAsync();
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

	[HttpPost]
	public async Task<ActionResult<ProductSet>> Post(ProductSet product)
	{
		if (ItemExists(product.Id))
		{
			return Problem("Product already exists");
		}
		_context.Products.Add(product);
		await _context.SaveChangesAsync();

		return CreatedAtAction("Get", new { id = product.Id }, product);
	}


	private bool ItemExists(int id)
	{
		return _context.Products.ItemExists(id);
	}
}