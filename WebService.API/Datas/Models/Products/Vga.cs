using WebService.API.Virtual.Abstract;

namespace WebService.API.Datas.Models.Products;

public record Vga : ModelBase
{
	public double Frequency { get; set; }
	public int Vram { get; set; }
	public virtual Product? Product { get; set; }
}