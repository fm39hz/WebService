using WebService.API.VirtualBase;

namespace WebService.API.Datas.Models;

public record Product(ISpecifications Specifications)
{
	public required long Id { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; }
	public double BasePrice { get; set; }
	public ISpecifications Specifications { get; set; } = Specifications;
}