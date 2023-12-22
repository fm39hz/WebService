using WebService.API.Virtual.Abstract;

namespace WebService.API.Datas.Models.Products;

public sealed record Mainboard : ProductBase
{
	public string? Socket { get; init; }
	public string? RamSlot { get; init; }
}