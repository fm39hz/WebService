using WebService.API.VirtualBase;

namespace WebService.API.Datas.Models.Products;

public record Product
{
	public required long Id { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; }
	public double BasePrice { get; set; }
	public Specifications? Specifications { get; set; }
}