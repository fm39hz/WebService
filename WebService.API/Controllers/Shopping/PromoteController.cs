using Microsoft.AspNetCore.Mvc;
using WebService.API.Datas.Context;
using WebService.API.Service.Factory;

namespace WebService.API.Controllers.Shopping;

[Route("api/Promote")]
[ApiController]
public class PromoteController : ControllerBase
{
	private readonly DataContext _context;

	public PromoteController(DataContext context)
	{
		_context = context;
	}

	[HttpGet("{productId:int}")]
	public async Task<ActionResult<double>> GetPromotePrice(int productId)
	{
		var _product = await _context.Products.FindAsync(productId);
		if (_product is null)
		{
			return NotFound();
		}
		return _product.GetPromotedPrice(PromoteFactory.Create(_product.Type!));
	}
}