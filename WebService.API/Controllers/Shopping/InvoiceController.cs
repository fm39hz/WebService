using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebService.API.Datas.Context;
using WebService.API.Datas.Models.Shopping;
using WebService.API.Service.Utils;

namespace WebService.API.Controllers.Shopping;

[Route("api/Invoices")]
[ApiController]
public class InvoiceController : ControllerBase
{
	private readonly DataContext _context;

	public InvoiceController(DataContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<List<Invoice>>> GetAll()
	{
		return await _context.Invoices.ToListAsync();
	}

	[HttpGet("{userUid}")]
	public IEnumerable<Invoice> GetAllOfUser(string userUid)
	{
		if (!ItemExists(userUid))
		{
			NotFound();
		}
		foreach (var _order in _context.Invoices.Where(o => o.UserUid == userUid))
		{
			yield return _order;
		}
	}

	[HttpGet("{id:int}")]
	public async Task<ActionResult<Invoice>> Get(int id)
	{
		if (!ItemExists(id))
		{
			NotFound();
		}
		var _invoice = await _context.Invoices.FindAsync(id);
		return _invoice;
	}

	private bool ItemExists(string uid)
	{
		return _context.Invoices.Any(o => o.UserUid == uid);
	}

	private bool ItemExists(int id)
	{
		return _context.Invoices.ItemExists(id);
	}
}