using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebService.API.Datas.Context;
using WebService.API.Datas.Models.Products;

namespace WebService.API.Controllers;

[Route("api/Vgas")]
[ApiController]
public class VgaController : ControllerBase
{
	private readonly DataContext _context;

	public VgaController(DataContext context)
	{
		_context = context;
	}

	// GET: api/Products
	[HttpGet]
	public async Task<ActionResult<IEnumerable<Vga>>> GetAll()
	{
		if (_context.Vgas.IsNullOrEmpty())
		{
			return NotFound();
		}
		return await _context.Vgas.ToListAsync();
	}

	// GET: api/Products/5
	[HttpGet("{id:long}")]
	public async Task<ActionResult<Vga>> Get(long id)
	{
		if (!ItemExists(id))
		{
			return NotFound();
		}
		var _item = await _context.Vgas.FindAsync(id);

		if (_item == null)
		{
			return NotFound();
		}

		return _item;
	}


	// PUT: api/Products/5
	// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
	[HttpPut("{id:long}")]
	public async Task<IActionResult> Put(long id, Cpu cpu)
	{
		if (id != cpu.Id)
		{
			return BadRequest();
		}
		_context.Entry(cpu).State = EntityState.Modified;

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

	// POST: api/Products
	// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
	[HttpPost]
	public async Task<ActionResult<Vga>> Post(Vga vga)
	{
		if (ItemExists(vga.Id))
		{
			return Problem("Cpu already exists");
		}
		_context.Vgas.Add(vga);
		await _context.SaveChangesAsync();

		return CreatedAtAction("Get", new { id = vga.Id }, vga);
	}

	// DELETE: api/Products/5
	[HttpDelete("{id:long}")]
	public async Task<IActionResult> Delete(long id)
	{
		if (!ItemExists(id))
		{
			return NotFound();
		}
		var _item = await _context.Vgas.FindAsync(id);
		if (_item == null)
		{
			return NotFound();
		}

		_context.Vgas.Remove(_item);
		await _context.SaveChangesAsync();

		return NoContent();
	}

	private bool ItemExists(long id)
	{
		return _context.Vgas.Any(e => e.Id == id);
	}
}