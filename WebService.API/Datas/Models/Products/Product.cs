using System.ComponentModel.DataAnnotations.Schema;
using WebService.API.Datas.Models.Products;
using WebService.API.Datas.Models.Shopping;
using WebService.API.Virtual.Interface;

namespace WebService.API.Virtual.Abstract;

public record Product : ModelBase
{
	public string? Name { get; set; }

	public int ConcreateId { get; set; }
	// Other properties

	[ForeignKey("ConcreateId")]
	public Cpu? Cpu { get; set; }

	[ForeignKey("ConcreateId")]
	public Vga? Vga { get; set; }

	public string? Description { get; set; }
	public string? ImageUrl { get; set; }
	public double BasePrice { get; set; }
	public int Quantity { get; set; }
	public string? Manufacturer { get; set; }

	public ShoppingItem? ShoppingItem { get; set; }

	public double GetFinalPrice(IPromoteStrategy appliedPromoteStrategy)
	{
		return appliedPromoteStrategy.CheckCondition(this)? appliedPromoteStrategy.DoDiscount(BasePrice) : BasePrice;
	}
}