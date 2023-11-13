using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebService.API.Datas.Context;
using WebService.API.Datas.Models;

namespace WebService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
	private readonly DataContext _context;

	public ItemsController(DataContext context)
	{
		_context = context;
	}

	// GET: api/Items
	[HttpGet]
	public async Task<ActionResult<IEnumerable<Item>>> GetItems()
	{
		if (!ItemExists(0))
		{
			return NotFound();
		}
		return await _context.Items.ToListAsync();
	}

	// GET: api/Items/5
	[HttpGet("{id:long}")]
	public async Task<ActionResult<Item>> GetItem(long id)
	{
		if (!ItemExists(id))
		{
			return NotFound();
		}
		var _item = await _context.Items.FindAsync(id);

		if (_item == null)
		{
			return NotFound();
		}

		return _item;
	}


	// PUT: api/Items/5
	// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
	[HttpPut("{id:long}/{type:alpha}/{discount:int}")]
	public async Task<IActionResult> PutItem(long id, Item item, string type, int discount)
	{
		if (id != item.Id)
		{
			return BadRequest();
		}
		var _item = new Item(
			AbstractRedirect.GetPromote(discount),
			AbstractRedirect.GetSpecifications(type, item.SpecId),
			item.BasePrice)
			{
				Id = item.Id,
				Name = item.Name,
				Description = item.Description
			};
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

		return NoContent();
	}

	// POST: api/Items
	// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
	[HttpPost]
	public async Task<ActionResult<Item>> PostItem(Item item)
	{
		if (_context.Items.Contains(item))
		{
			return Problem("Item already exists");
		}
		_context.Items.Add(item);
		await _context.SaveChangesAsync();

		return CreatedAtAction("GetItem", new { id = item.Id }, item);
	}

	// DELETE: api/Items/5
	[HttpDelete("{id:long}")]
	public async Task<IActionResult> DeleteItem(long id)
	{
		if (!ItemExists(id))
		{
			return NotFound();
		}
		var _item = await _context.Items.FindAsync(id);
		if (_item == null)
		{
			return NotFound();
		}

		_context.Items.Remove(_item);
		await _context.SaveChangesAsync();

		return NoContent();
	}

	private bool ItemExists(long id)
	{
		return _context.Items.Any(e => e.Id == id);
	}
}