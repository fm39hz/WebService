namespace WebService.API.Datas.Models.Shopping;

public record ShoppingCart(List<ShoppingItem> ShoppingItems)
{
	public double GetFinalPrice()
	{
		return ShoppingItems.Sum(items => items.GetFinalPrice());
	}
}