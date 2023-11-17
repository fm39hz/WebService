namespace WebService.API.VirtualBase;

public interface ISpecifications
{
	public long Id { get; set; }
	public string? Brand { get; set; }
	public string GetSpec();
}