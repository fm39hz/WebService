using WebService.API.VirtualBase;

namespace WebService.API.Datas.Models.Products;

public record Product(Specifications Specifications)
{
	public required long Id { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; }
	public double BasePrice { get; set; }
}