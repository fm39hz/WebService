using WebService.API.VirtualBase;

namespace WebService.API.Datas.Models;

public record Vga : ISpecifications
{
	public double Frequency { get; set; }
	public int Vram { get; set; }
	public required long Id { get; set; }
	public string? Brand { get; set; }
}