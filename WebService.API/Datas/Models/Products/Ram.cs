using WebService.API.Virtual.Abstract;

namespace WebService.API.Datas.Models.Products;

public sealed record Ram : ProductBase
{
	public int Value { get; set; }
	public string? Technology { get; set; }
	public int Bus { get; set; }
}