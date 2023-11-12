namespace WebService.API.Models;

public class CpuSpec : ISpecifications
{
	public required long Id { get; set; }
	public string? Socket { get; set; }
	public string? TradeMark { get; set; }
	public string? Voltage { get; set; }
}