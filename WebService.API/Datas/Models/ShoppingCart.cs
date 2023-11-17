namespace WebService.API.Datas.Models;

public record ShoppingCart
{
	public required List<ShoppingItem> ShoppingItems { get; init; } = new();

	public double GetFinalPrice()
	{
		return ShoppingItems.Sum(items => items.GetFinalPrice());
	}
}