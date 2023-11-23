namespace WebService.API.VirtualBase;

public abstract record Specifications(long Id)
{
	public long Id { get; set; } = Id;
	public required string Type { get; set; }
}