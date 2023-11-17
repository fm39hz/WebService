using WebService.API.Datas.Models.Products;
using WebService.API.VirtualBase;

namespace WebService.API.Datas.Models.Shopping;

public record ShoppingItem(IEnumerable<IPromoteStrategy> AppliedPromoteStrategy)
{
	public required long Id { get; set; }
	public required Product Target { get; set; }
	public required int Quantity { get; set; }
	public bool IsSelected { get; set; }

	public double GetFinalPrice()
	{
		return AppliedPromoteStrategy.Aggregate(Target.BasePrice,
			(current, promote) => promote.CheckCondition(Target)? promote.DoDiscount(current) : Target.BasePrice);
	}
}