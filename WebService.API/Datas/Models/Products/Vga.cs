using WebService.API.Virtual.Abstract;

namespace WebService.API.Datas.Models.Products;

public record Vga : ModelBase
{
	public double Frequency { get; init; }
	public int Vram { get; init; }
	public virtual Product? Product { get; set; }
}