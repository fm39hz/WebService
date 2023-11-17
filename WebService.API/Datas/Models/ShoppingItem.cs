using WebService.API.VirtualBase;

namespace WebService.API.Datas.Models;

public class ShoppingItem
{
	public required long Id { get; set; }
	public required Product Target { get; set; }
	public required int Quantity { get; set; }
	public bool IsSelected { get; set; }
	public List<IPromoteStrategy> AppliedPromoteStrategy { get; } = new();

	public double GetFinalPrice()
	{
		return AppliedPromoteStrategy.Aggregate(Target.BasePrice, (current, promote) => promote.DoDiscount(current));
	}
}