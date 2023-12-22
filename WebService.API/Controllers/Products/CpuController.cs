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

	[HttpGet]
	public async Task<ActionResult<List<Cpu>>> GetAll()
	{
		var _cpus = await _context.Cpus.ToListAsync();
		return _cpus.Select(cpu => cpu.WithProduct(_context.Products)).ToList();
	}

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

	[HttpPut]
	public async Task<IActionResult> Put(Cpu cpu)
	{
		if (!ItemExists(cpu.Id))
		{
			return NotFound();
		}
		_context.Update(cpu);
		await _context.SaveChangesAsync();
		return Ok();
	}

	[HttpPost]
	public async Task<ActionResult<Cpu>> Post(Cpu cpu)
	{
		if (ItemExists(cpu.Id))
		{
			return Problem("Cpu already exists");
		}
		if (cpu.Product is null || cpu.Product.Id > 0)
		{
			return Problem("Product must been specified without id");
		}
		cpu.Product!.Type = "Cpu";
		_context.Cpus.Add(cpu);
		await _context.SaveChangesAsync();

		return CreatedAtAction("Get", new { id = cpu.Id }, cpu);
	}

	[HttpDelete("{id:int}")]
	public async Task<IActionResult> Delete(int id)
	{
		var _item = await _context.Cpus.FindAsync(id);
		if (_item == null || !ItemExists(id))
		{
			return NotFound();
		}
		_context.Cpus.Remove(_item.WithProduct(_context.Products));
		await _context.SaveChangesAsync();
		return Ok();
	}

	private bool ItemExists(int id)
	{
		return _context.Cpus.ItemExists(id);
	}
}