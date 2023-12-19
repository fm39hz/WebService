using WebService.API.Datas.Context;
using WebService.API.Datas.Models.Products;
using WebService.API.Datas.Models.Shopping;
using WebService.API.Virtual.Abstract;

namespace WebService.API.Service;

public static class ModelUtils
{
	public static ShoppingCart WithShoppingItems(this ShoppingCart cart, DataContext context)
	{
		foreach (var _shoppingItem in context.ShoppingItems)
		{
			if (_shoppingItem.CartId == cart.Id)
			{
			}
		}
		return cart with
		{
			ShoppingItems = cart.ShoppingItems.WithShoppingProduct(context).ToList()
		};
	}

	public static IEnumerable<ShoppingItem> WithShoppingProduct(this IEnumerable<ShoppingItem> items,
		DataContext context)
	{
		return items.Select(shoppingItem => shoppingItem.WithProduct(context.Products));
	}

	public static ShoppingItem WithProduct(this ShoppingItem item, IEnumerable<Product> products)
	{
		item.Target = products.First(p => p.Id == item.ProductId);
		return item;
	}

	public static Cpu WithProduct(this Cpu concrete, IEnumerable<Product> products)
	{
		concrete.Product = products.First(p => p.SpecificationId == concrete.Id);
		return concrete;
	}

	public static Vga WithProduct(this Vga concrete, IEnumerable<Product> products)
	{
		concrete.Product = products.First(p => p.SpecificationId == concrete.Id);
		return concrete;
	}
}