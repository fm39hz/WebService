namespace WebService.API.Virtual.Abstract;

public record Product : ModelBase
{
	public string? Name { get; init; }
	public int ConcreateId { get; init; }
	public string? Description { get; init; }
	public string? ImageUrl { get; init; }
	public double BasePrice { get; init; }
	public int InStock { get; set; }
	public string? Manufacturer { get; init; }
}