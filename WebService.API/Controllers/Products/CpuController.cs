using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebService.API.Datas.Context;
using WebService.API.Datas.Models.Products;
using WebService.API.Service;
using WebService.API.Service.Utils;

namespace WebService.API.Controllers.Products;

[Route("api/Cpus")]
[ApiController]
public class CpuController : ControllerBase
{
	private readonly DataContext _context;

	public CpuController(DataContext context)
	{
		_context = context;
	}

	// GET: api/Cpus
	[HttpGet]
	public async Task<ActionResult<List<Cpu>>> GetAll()
	{
		var _cpus = await _context.Cpus.ToListAsync();
		return _cpus.Select(cpu => cpu.WithProduct(_context.Products)).ToList();
	}

	// GET: api/Cpus/0
	[HttpGet("{id:int}")]
	public async Task<ActionResult<Cpu>> Get(int id)
	{
		var _item = await _context.Cpus.FindAsync(id);
		if (!ItemExists(id) || _item == null)
		{
			return NotFound();
		}
		return _item.WithProduct(_context.Products);
	}


	// PUT: api/Cpus/0
	// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
	[HttpPut("{id:int}")]
	public async Task<IActionResult> Put(int id, Cpu cpu)
	{
		if (!ItemExists(id))
		{
			return NotFound();
		}
		cpu.Id = id;
		_context.Update(cpu);
		await _context.SaveChangesAsync();
		return Ok();
	}

	// POST: api/Cpus
	// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
	[HttpPost]
	public async Task<ActionResult<Cpu>> Post(Cpu cpu)
	{
		if (ItemExists(cpu.Id))
		{
			return Problem("Cpu already exists");
		}
		cpu.Product!.Type = "Cpu";
		_context.Cpus.Add(cpu);
		await _context.SaveChangesAsync();

		return CreatedAtAction("Get", new { id = cpu.Id }, cpu);
	}

	// DELETE: api/Cpus/0
	[HttpDelete("{id:int}")]
	public async Task<IActionResult> Delete(int id)
	{
		if (!ItemExists(id))
		{
			return NotFound();
		}
		var _item = await _context.Cpus.FindAsync(id);
		if (_item == null)
		{
			return NotFound();
		}
		_context.Cpus.Remove(_item.WithProduct(_context.Products));
		_context.Products.RemoveProduct(_item);
		await _context.SaveChangesAsync();
		return NoContent();
	}

	private bool ItemExists(int id)
	{
		return _context.Cpus.ItemExists(id);
	}
}