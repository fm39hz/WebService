using WebService.API.Interface;

namespace WebService.API.Models;

public record Item
{
	public Item()
	{
	}

	public Item(IPromoteStrategy promotes, ISpecifications spec)
	{
		FinalPrice = promotes.DoDiscount(BasePrice);
		SpecId = spec.Id;
	}

	public required long Id { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; }
	public double BasePrice { get; set; }
	public double FinalPrice { get; set; }
	public long SpecId { get; set; }
}