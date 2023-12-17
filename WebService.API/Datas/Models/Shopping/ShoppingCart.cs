using WebService.API.Virtual.Abstract;

namespace WebService.API.Datas.Models.Shopping;

public record ShoppingCart() : ModelBase
{
	public ShoppingCart(IEnumerable<ShoppingItem>? shoppingItems) : this()
	{
		ShoppingItems = shoppingItems;
	}

	public IEnumerable<ShoppingItem>? ShoppingItems { get; }

	public double GetFinalPrice()
	{
		return (ShoppingItems ?? throw new InvalidOperationException()).Sum(items => items.GetFinalPrice());
	}
}