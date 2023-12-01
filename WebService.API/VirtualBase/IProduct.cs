namespace WebService.API.VirtualBase;

public interface IProduct
{
	public long Id { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; }
	public double BasePrice { get; set; }
}