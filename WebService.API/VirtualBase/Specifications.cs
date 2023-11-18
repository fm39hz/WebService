namespace WebService.API.VirtualBase;

public abstract record Specifications
{
	public required long Id { get; init; }
	public string? Brand { get; set; }

	public abstract string GetSpec();
}