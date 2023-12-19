using WebService.API.Controllers;
using WebService.API.Virtual.Abstract;
using WebService.API.Virtual.Interface;

namespace WebService.API.Datas.Models.Shopping;

public record ShoppingItem : ModelBase
{
	public IPromoteStrategy AppliedPromoteStrategy
	{
		get { return AbstractFactory.GetPromote(PromoteType!); }
	}

	public string? PromoteType { get; init; }
	public virtual Product Target { get; set; } = null!;
	public int ProductId { get; init; }
	public int CartId { get; init; }
	public int Quantity { get; init; }
	public int IsSelected { get; init; }

	public double GetFinalPrice()
	{
		return Target.GetPromotePrice(AppliedPromoteStrategy) * Quantity;
	}
}