using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebService.API.Datas.Context;
using WebService.API.VirtualBase;

namespace WebService.API.Controllers;

[Route("api/Stock")]
[ApiController]
public class StockController : ControllerBase
{
	private readonly DataContext _context;

	public StockController(DataContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Dictionary<IProduct, int>>>> GetAll()
	{
		if ((await _context.Stock.ToListAsync()).IsNullOrEmpty())
		{
			return NotFound();
		}
		return await _context.Stock.ToListAsync();
	}
}