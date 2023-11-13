using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebService.API.Datas.Context;
using WebService.API.Datas.Models;

namespace WebService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
	private readonly DataContext _context;

	public ProductsController(DataContext context)
	{
		_context = context;
	}

	// GET: api/Products
	[HttpGet]
	public async Task<ActionResult<IEnumerable<Product>>> GetAll()
	{
		if (!ProductExists(0))
		{
			return NotFound();
		}
		return await _context.Products.ToListAsync();
	}

	// GET: api/Products/5
	[HttpGet("{id:long}")]
	public async Task<ActionResult<Product>> Get(long id)
	{
		if (!ProductExists(id))
		{
			return NotFound();
		}
		var _item = await _context.Products.FindAsync(id);

		if (_item == null)
		{
			return NotFound();
		}

		return _item;
	}


	// PUT: api/Products/5
	// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
	[HttpPut("{id:long}/{type:alpha}/{discount:int}")]
	public async Task<IActionResult> Put(long id, Product product, string type, int discount)
	{
		if (id != product.Id)
		{
			return BadRequest();
		}
		var _item = new Product(
			AbstractRedirect.GetPromote(discount),
			AbstractRedirect.GetSpecifications(type, product.SpecId),
			product.BasePrice)
			{
				Id = product.Id,
				Name = product.Name,
				Description = product.Description
			};
		_context.Entry(_item).State = EntityState.Modified;

		try
		{
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException)
		{
			if (!ProductExists(id))
			{
				return NotFound();
			}
			throw;
		}

		return NoContent();
	}

	// POST: api/Products
	// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
	[HttpPost]
	public async Task<ActionResult<Product>> Post(Product product)
	{
		if (_context.Products.Contains(product))
		{
			return Problem("Product already exists");
		}
		_context.Products.Add(product);
		await _context.SaveChangesAsync();

		return CreatedAtAction("Get", new { id = product.Id }, product);
	}

	// DELETE: api/Products/5
	[HttpDelete("{id:long}")]
	public async Task<IActionResult> Delete(long id)
	{
		if (!ProductExists(id))
		{
			return NotFound();
		}
		var _item = await _context.Products.FindAsync(id);
		if (_item == null)
		{
			return NotFound();
		}

		_context.Products.Remove(_item);
		await _context.SaveChangesAsync();

		return NoContent();
	}

	private bool ProductExists(long id)
	{
		return _context.Products.Any(e => e.Id == id);
	}
}