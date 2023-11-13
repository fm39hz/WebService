using WebService.API.VirtualBase;

namespace WebService.API.Datas.Models;

public record Item
{
	public Item()
	{
		FinalPrice = BasePrice;
		SpecId = 0;
	}

	public Item(IPromoteStrategy promotes, ISpecifications spec, double basePrice)
	{
		BasePrice = basePrice;
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