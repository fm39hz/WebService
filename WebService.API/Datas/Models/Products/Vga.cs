using WebService.API.Virtual.Abstract;

namespace WebService.API.Datas.Models.Products;

public record Vga : ModelBase
{
	public float Frequency { get; set; }
	public int Vram { get; set; }
	public Product? Product { get; set; }
}