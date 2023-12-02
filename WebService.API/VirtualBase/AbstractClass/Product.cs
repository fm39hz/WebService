namespace WebService.API.VirtualBase.Abstract;

public abstract record Product : ModelBase
{
	public string? Name { get; set; }
	public string? Description { get; set; }
	public double BasePrice { get; set; }
}