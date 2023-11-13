using WebService.API.VirtualBase;

namespace WebService.API.Datas.Models;

public record Cpu : ISpecifications
{
	public string? Socket { get; set; }
	public string? Voltage { get; set; }
	public int Core { get; set; }
	public int Thread { get; set; }
	public double Frequency { get; set; }
	public required long Id { get; set; }
	public string? Brand { get; set; }
}