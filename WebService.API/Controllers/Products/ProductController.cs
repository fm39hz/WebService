using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebService.API.Datas.Context;
using WebService.API.Service.Factory;
using WebService.API.Service.Utils;
using WebService.API.Virtual.Abstract;
using WebService.API.Virtual.Interface;

namespace WebService.API.Controllers.Products;

[Route("api/Products")]
[ApiController]
public class ProductController : ControllerBase
{
	private readonly DataContext _context;

	public ProductController(DataContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Product>>> GetAll()
	{
		var _products = await _context.Products.ToListAsync();
		if (_products.IsNullOrEmpty())
		{
			return NotFound();
		}
		return _products;
	}

	[HttpGet("{id:int}")]
	public async Task<ActionResult<Product>> Get(int id)
	{
		var _item = await _context.Products.FindAsync(id);
		if (!ItemExists(id) || _item == null)
		{
			return NotFound();
		}
		return _item;
	}

	[HttpPut]
	public async Task<IActionResult> Put(Product product)
	{
		if (!ItemExists(product.Id))
		{
			return NotFound();
		}
		_context.Update(product);
		await _context.SaveChangesAsync();
		return Ok();
	}

	private bool ItemExists(int id)
	{
		return _context.Products.ItemExists(id);
	}

	[HttpGet("Promoted/{id:int}")]
	public async Task<ActionResult<double>> GetPromotePrice(int id)
	{
		var _product = await _context.Products.FindAsync(id);
		if (_product is null)
		{
			return NotFound();
		}
		return _product.GetPromotedPrice(PromoteFactory.Create(_product.Type!));
	}

	[HttpGet("PromoteDetails/{id:int}")]
	public async Task<ActionResult<IPromoteStrategy>> GetPromotedDetails(int id)
	{
		var _product = await _context.Products.FindAsync(id);
		if (_product is null)
		{
			return NotFound();
		}
		return Ok(PromoteFactory.Create(_product.Type!));
	}
}