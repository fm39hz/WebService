using WebService.API.Datas.Models.Products;

namespace WebService.API.VirtualBase;

public abstract record Specification
{
	public long Id { get; set; }
	public long ProductId { get; set; }
	public required Product ProductTarget { get; set; }

	public abstract string GetSpec();
}