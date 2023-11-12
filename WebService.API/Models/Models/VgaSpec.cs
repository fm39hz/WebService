namespace WebService.API.Models;

public class VgaSpec : ISpecifications
{
	public required long Id { get; set; }
	public int Vram { get; set; }
	public string? TradeMark { get; set; }
}