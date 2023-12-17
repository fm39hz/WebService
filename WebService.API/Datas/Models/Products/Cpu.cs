using WebService.API.Virtual.Abstract;

namespace WebService.API.Datas.Models.Products;

public record Cpu : ModelBase
{
	public string? Socket { get; init; }
	public int Tdp { get; init; }
	public int Core { get; init; }
	public int Thread { get; init; }
	public double Frequency { get; init; }
	public string? Manufacturer { get; init; }
	public virtual Product? Product { get; set; }
}