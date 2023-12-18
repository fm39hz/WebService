using WebService.API.Controllers;
using WebService.API.Virtual.Abstract;
using WebService.API.Virtual.Interface;

namespace WebService.API.Datas.Models.Shopping;

public sealed record ShoppingItem : ModelBase
{
	public IPromoteStrategy AppliedPromoteStrategy
	{
		get { return AbstractFactory.GetPromote(Promote); }
	}

	public int Promote { get; init; }
	public Product Target { get; init; } = null!;
	public ShoppingCart Cart { get; init; } = null!;
	public int ProductId { get; init; }
	public int CartId { get; init; }
	public int IsSelected { get; set; }

	public double GetFinalPrice()
	{
		return Target.GetFinalPrice(AppliedPromoteStrategy);
	}
}