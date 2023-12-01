using WebService.API.VirtualBase;

namespace WebService.API.Datas.Models.Products;

public record Cpu : IProduct
{
	public string? Socket { get; set; }
	public int Tdp { get; set; }
	public int Core { get; set; }
	public int Thread { get; set; }
	public float Frequency { get; set; }
	public string? Manufacturer { get; set; }
	public required long Id { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; }
	public float BasePrice { get; set; }
}