using WebService.API.VirtualBase;

namespace WebService.API.Datas.Models.Products;

public record Vga : IProduct
{
	public double Frequency { get; set; }
	public int Vram { get; set; }
	public string? Manufacturer { get; set; }
	public required long Id { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; }
	public double BasePrice { get; set; }
}