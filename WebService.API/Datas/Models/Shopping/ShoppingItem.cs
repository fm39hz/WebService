using WebService.API.Virtual.Abstract;
using WebService.API.Virtual.Interface;

namespace WebService.API.Datas.Models.Shopping;

public sealed record ShoppingItem() : ModelBase
{
	public ShoppingItem(IEnumerable<IPromoteStrategy>? appliedPromoteStrategy, Product target) : this()
	{
		AppliedPromoteStrategy = appliedPromoteStrategy;
		Target = target;
	}

	public IEnumerable<IPromoteStrategy>? AppliedPromoteStrategy { get; }
	public required Product Target { get; init; }
	public required int Quantity { get; set; }
	public bool IsSelected { get; set; }

	public double GetFinalPrice()
	{
		return (AppliedPromoteStrategy ?? throw new InvalidOperationException()).Aggregate(Target.BasePrice,
			(current, promote) => promote.CheckCondition(Target)? promote.DoDiscount(current) : Target.BasePrice);
	}
}