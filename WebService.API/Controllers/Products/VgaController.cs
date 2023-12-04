using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebService.API.Datas.Context;
using WebService.API.Datas.Models.Products;
using WebService.API.Service;

namespace WebService.API.Controllers.Products;

[Route("api/Vgas")]
[ApiController]
public class VgaController : ControllerBase
{
	private readonly DataContext _context;

	public VgaController(DataContext context)
	{
		_context = context;
	}

	// GET: api/Vgas
	[HttpGet]
	public async Task<ActionResult<IEnumerable<Vga>>> GetAll()
	{
		if (_context.Vgas.IsNullOrEmpty())
		{
			return NotFound();
		}
		return await _context.Vgas.ToListAsync();
	}

	// GET: api/Vgas/0
	[HttpGet("{id:int}")]
	public async Task<ActionResult<Vga>> Get(int id)
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


	// PUT: api/Vgas/5
	// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
	[HttpPut("{id:int}")]
	public async Task<IActionResult> Put(int id, Vga vga)
	{
		vga.Id = id;
		_context.Update(vga);

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

	// POST: api/Vgas
	// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
	[HttpPost]
	public async Task<ActionResult<Vga>> Post(Vga vga)
	{
		if (ItemExists(vga.Id))
		{
			return Problem("Vga already exists");
		}
		_context.EnsureProductsExists(vga);
		_context.Vgas.Add(vga);
		await _context.SaveChangesAsync();

		return CreatedAtAction("Get", new { id = vga.Id }, vga);
	}

	// DELETE: api/Vgas/5
	[HttpDelete("{id:int}")]
	public async Task<IActionResult> Delete(int id)
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

	private bool ItemExists(int id)
	{
		return _context.Vgas.ItemExists(id);
	}
}