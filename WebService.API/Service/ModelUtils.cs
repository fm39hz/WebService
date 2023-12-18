using WebService.API.Datas.Context;
using WebService.API.Datas.Models.Products;
using WebService.API.Datas.Models.Shopping;
using WebService.API.Virtual.Abstract;

namespace WebService.API.Service;

public static class ModelUtils
{
	public static ShoppingCart WithShoppingItems(this ShoppingCart cart, DataContext context)
	{
		foreach (var _shoppingItem in context.ShoppingItems.Where(i =>
					i.CartId == cart.Id && !cart.ShoppingItems.Contains(i)))
		{
			cart.ShoppingItems.Add(_shoppingItem.WithProduct(context.Products));
		}
		return cart;
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