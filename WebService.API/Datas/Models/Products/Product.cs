using WebService.API.Virtual.Interface;

namespace WebService.API.Virtual.Abstract;

public record Product : ModelBase
{
	public string? Name { get; init; }
	public int SpecificationId { get; init; }
	public string? Description { get; init; }
	public string? ImageUrl { get; init; }
	public double BasePrice { get; init; }
	public int InStock { get; init; }
	public string? Manufacturer { get; init; }
	public int ReviewCount { get; init; }
	public double Rating { get; init; }

	public string? Type { get; set; }

	public double GetPromotePrice(IPromoteStrategy promoteStrategy)
	{
		return promoteStrategy.CheckCondition(this)
			? promoteStrategy.DoDiscount(BasePrice)
			: BasePrice;
	}
}