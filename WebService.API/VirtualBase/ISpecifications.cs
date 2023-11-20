namespace WebService.API.VirtualBase;

public interface ISpecifications
{
	public long Id { get; }
	public string? Brand { get; set; }

	public string GetSpec();
}