using WebService.API.Virtual.Abstract;

namespace WebService.API.Datas.Models.Shopping;

public record ShoppingCart : ModelBase
{
	public string? UserUid { get; init; }

	public virtual List<ShoppingItem> ShoppingItems { get; init; } = new();

	public double GetFinalPrice()
	{
		return (ShoppingItems ?? throw new NullReferenceException())
		.Sum(items => items.IsSelected == 1? items.GetFinalPrice() : 0);
	}
}