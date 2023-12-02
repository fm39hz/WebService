using WebService.API.VirtualBase.Abstract;

namespace WebService.API.Datas.Models.Products;

public record Vga : Product
{
	public float Frequency { get; set; }
	public int Vram { get; set; }
	public string? Manufacturer { get; set; }
}