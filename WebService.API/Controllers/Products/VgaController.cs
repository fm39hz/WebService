using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebService.API.Datas.Context;
using WebService.API.Datas.Models.Products;
using WebService.API.Service;
using WebService.API.Service.Utils;

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

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Vga>>> GetAll()
	{
		var _vgas = await _context.Vgas.ToListAsync();
		if (_vgas.IsNullOrEmpty())
		{
			return NotFound();
		}
		return _vgas.Select(v => v.WithProduct(_context.Products)).ToList();
	}

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

		return _item.WithProduct(_context.Products);
	}

	[HttpPut]
	public async Task<IActionResult> Put(Vga vga)
	{
		if (!ItemExists(vga.Id))
		{
			return NotFound();
		}
		_context.Update(vga);
		await _context.SaveChangesAsync();
		return Ok();
	}

	[HttpPost]
	public async Task<ActionResult<Vga>> Post(Vga vga)
	{
		if (ItemExists(vga.Id))
		{
			return Problem("Vga already exists");
		}
		if (vga.Product is null)
		{
			return Problem("Product must been specified");
		}
		vga.Product!.Type = "Vga";
		_context.Vgas.Add(vga);
		await _context.SaveChangesAsync();

		return CreatedAtAction("Get", new { id = vga.Id }, vga);
	}

	[HttpDelete("{id:int}")]
	public async Task<IActionResult> Delete(int id)
	{
		var _item = await _context.Vgas.FindAsync(id);
		if (_item == null || !ItemExists(id))
		{
			return NotFound();
		}
		_context.Vgas.Remove(_item.WithProduct(_context.Products));
		await _context.SaveChangesAsync();
		return NoContent();
	}

	private bool ItemExists(int id)
	{
		return _context.Vgas.ItemExists(id);
	}
}