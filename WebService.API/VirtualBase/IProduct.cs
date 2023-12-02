namespace WebService.API.VirtualBase;

public abstract record Product
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; }
	public double BasePrice { get; set; }
}