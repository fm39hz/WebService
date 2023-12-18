using WebService.API.Datas.Models.Shopping;

namespace WebService.API.Service;

public static class ModelUtils
{
	public static ShoppingCart WithProducts(this ShoppingCart cart, IEnumerable<ShoppingItem> shoppingItems)
	{
		foreach (var _shoppingItem in shoppingItems.Where(i => i.CartId == cart.Id && !cart.ShoppingItems.Contains(i)))
		{
			cart.ShoppingItems.Add(_shoppingItem);
		}
		return cart;
	}
}