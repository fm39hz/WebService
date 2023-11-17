namespace WebService.API.Datas.Models;

public class ShoppingCart
{
	public required List<ShoppingItem> ShoppingItems { get; init; } = new();

	public double GetFinalPrice()
	{
		return ShoppingItems.Sum(items => items.GetFinalPrice());
	}
}