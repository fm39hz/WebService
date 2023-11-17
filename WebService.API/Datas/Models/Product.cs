using WebService.API.VirtualBase;

namespace WebService.API.Datas.Models;

public record Product
{
	public Product()
	{
		SpecId = 0;
	}

	public Product(ISpecifications spec)
	{
		SpecId = spec.Id;
	}

	public required long Id { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; }
	public double BasePrice { get; set; }
	public long SpecId { get; set; }
}