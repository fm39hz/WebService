using WebService.API.Virtual.Abstract;

namespace WebService.API.Datas.Models.Products;

public sealed record Ram : ProductBase
{
	public string? Value { get; set; }
	public string? Technology { get; set; }
	public string? Bus { get; set; }
}