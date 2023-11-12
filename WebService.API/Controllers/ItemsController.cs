using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebService.API.VirtualBase;
using WebService.API.Datas.Models;
using WebService.API.Datas.DBContext;
using WebService.API.Instanced.PromoteStrategy;

namespace WebService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
	private readonly ItemDbContext _context;

	public ItemsController(ItemDbContext context)
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

	private static ISpecifications GetSpec(string type, long id)
	{
		return type switch
		{
			"cpu" => new CpuSpec
			{
				Id = id
			},
			"vga" => new VgaSpec
			{
				Id = id
			},
			_ => throw new InvalidDataException()
		};
	}

	private static IPromoteStrategy GetStrategy(int strategy)
	{
		return strategy switch
		{
			15 => new FifteenPercentDiscount(),
			_ => new NoDiscount()
		};
	}

	// PUT: api/Items/5
	// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
	[HttpPut("{id:long}")]
	public async Task<IActionResult> PutItem(long id, Item item,string type,int discount)
	{
		if (id != item.Id)
		{
			return BadRequest();
		}
		var _item = new Item(GetStrategy(discount), GetSpec(type, item.SpecId))
		{
			Id = item.Id,
			Name = item.Name,
			BasePrice = item.BasePrice,
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