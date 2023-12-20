using WebService.API.Virtual.Abstract;

namespace WebService.API.Datas.Models.Products;

public sealed record Vga : ProductBase
{
	public double Frequency { get; init; }
	public int Vram { get; init; }
}