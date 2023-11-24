using Microsoft.AspNetCore.Mvc;
using WebService.API.Datas.Context;

namespace WebService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpecController : ControllerBase
{
	private readonly DataContext _context;

	public SpecController(DataContext context)
	{
		_context = context;
	}

	// GET: api/Products/5
	[HttpGet("{id:long}")]
	public async Task<ActionResult<string>> GetId(long id)
	{
		if (!SpecificationsExists(id))
		{
			return NotFound();
		}
		var _item = await _context.Specifications.FindAsync(id);

		return _item == null? NotFound() : _item.GetSpec();
	}

	private bool SpecificationsExists(long id)
	{
		return _context.Specifications.Any(spec => spec.Id == id);
	}
}