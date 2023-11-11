namespace WebService.API.Models;

public class Item
{
	public long Id { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; }
	public double BasePrice { get; set; }
	public string? ItemsType { get; set; }
}