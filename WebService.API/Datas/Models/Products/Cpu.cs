using WebService.API.Virtual.Abstract;

namespace WebService.API.Datas.Models.Products;

public sealed record Cpu : ProductBase
{
	public string? Socket { get; init; }
	public int Tdp { get; init; }
	public int Core { get; init; }
	public int Thread { get; init; }
	public double Frequency { get; init; }
}