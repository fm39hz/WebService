using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebService.API.Datas.Context;
using WebService.API.Datas.Models.Products;

namespace WebService.API.Controllers;

[Route("api/Cpus")]
[ApiController]
public class CpuController : ControllerBase
{
	private readonly DataContext _context;

	public CpuController(DataContext context)
	{
		_context = context;
	}

	// GET: api/Products
	[HttpGet]
	public async Task<ActionResult<IEnumerable<Cpu>>> GetAll()
	{
		if (!ProductExists(0))
		{
			return NotFound();
		}
		return await _context.Cpus.ToListAsync();
	}

	// GET: api/Products/5
	[HttpGet("{id:long}")]
	public async Task<ActionResult<Cpu>> Get(long id)
	{
		if (!ProductExists(id))
		{
			return NotFound();
		}
		var _item = await _context.Cpus.FindAsync(id);

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
	public async Task<ActionResult<Cpu>> Post(Cpu cpu)
	{
		if (_context.Cpus.Contains(cpu))
		{
			return Problem("ProductTarget already exists");
		}
		_context.Cpus.Add(cpu);
		await _context.SaveChangesAsync();

		return CreatedAtAction("Get", new { id = cpu.Id }, cpu);
	}

	// DELETE: api/Products/5
	[HttpDelete("{id:long}")]
	public async Task<IActionResult> Delete(long id)
	{
		if (!ProductExists(id))
		{
			return NotFound();
		}
		var _item = await _context.Cpus.FindAsync(id);
		if (_item == null)
		{
			return NotFound();
		}

		_context.Cpus.Remove(_item);
		await _context.SaveChangesAsync();

		return NoContent();
	}

	private bool ProductExists(long id)
	{
		return _context.Cpus.Any(e => e.Id == id);
	}
}