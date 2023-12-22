using WebService.API.Service.Factory;
using WebService.API.Virtual.Abstract;
using WebService.API.Virtual.Interface;

namespace WebService.API.Datas.Models.Shopping;

public record ShoppingItem : ModelBase
{
	public IPromoteStrategy AppliedPromoteStrategy
	{
		get { return PromoteFactory.Create(PromoteType!); }
	}

	public string? OrderStatus { get; set; } = "Waiting";
	public int? OrderId { get; init; }
	public string? PromoteType { get; set; }
	public virtual Product? Target { get; set; }
	public int ProductId { get; init; }
	public int CartId { get; init; }
	public int Quantity { get; set; }
	public int IsSelected { get; init; }

	public double GetFinalPrice()
	{
		return Target.GetPromotedPrice(AppliedPromoteStrategy) * Quantity;
	}
}