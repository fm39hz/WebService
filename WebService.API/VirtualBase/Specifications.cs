namespace WebService.API.VirtualBase;

public abstract record Specification
{
	public long Id { get; set; }
	public long ProductId { get; set; }

	public abstract string GetSpec();
}