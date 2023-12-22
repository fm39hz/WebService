using WebService.API.Virtual.Abstract;

namespace WebService.API.Datas.Models.Products;

public sealed record Cpu : ProductBase
{
	public string? Socket { get; init; }
	public string? Tdp { get; init; }
	public string? Core { get; init; }
	public string? Thread { get; init; }
	public string? Frequency { get; init; }
}