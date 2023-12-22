using WebService.API.Virtual.Abstract;

namespace WebService.API.Datas.Models.Products;

public sealed record Vga : ProductBase
{
	public string? Frequency { get; init; }
	public string? Vram { get; init; }
}