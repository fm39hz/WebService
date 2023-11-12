namespace WebService.API.Models;

public record VgaSpec : ISpecifications
{
	public required long Id { get; set; }
	public int Vram { get; set; }
	public string? TradeMark { get; set; }
}