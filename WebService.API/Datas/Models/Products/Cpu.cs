using WebService.API.VirtualBase.Abstract;

namespace WebService.API.Datas.Models.Products;

public record Cpu : Product
{
	public string? Socket { get; set; }
	public int Tdp { get; set; }
	public int Core { get; set; }
	public int Thread { get; set; }
	public double Frequency { get; set; }
	public string? Manufacturer { get; set; }
}