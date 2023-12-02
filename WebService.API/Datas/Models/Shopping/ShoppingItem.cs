using WebService.API.VirtualBase;

namespace WebService.API.Datas.Models.Shopping;

public sealed record ShoppingItem(IEnumerable<IPromoteStrategy> AppliedPromoteStrategy, Product Target)
{
	public required long Id { get; set; }
	public required Product Target { get; init; } = Target;
	public required int Quantity { get; set; }
	public bool IsSelected { get; set; }

	public double GetFinalPrice()
	{
		return AppliedPromoteStrategy.Aggregate(Target.BasePrice,
			(current, promote) => promote.CheckCondition(Target)? promote.DoDiscount(current) : Target.BasePrice);
	}
}