namespace WebService.API.Models;

public record VgaSpec : ISpecifications
{
	public required long Id { get; set; }
	public string? Brand { get; set; }
	public double Frequency { get; set; }
	public int Vram { get; set; }
}