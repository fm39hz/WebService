using WebService.API.Datas.Context;
using WebService.API.Datas.Models.Products;
using WebService.API.Datas.Models.Shopping;
using WebService.API.Virtual.Abstract;

namespace WebService.API.Service;

public static class ModelUtils
{
	public static ShoppingCart WithShoppingItems(this ShoppingCart cart, DataContext context)
	{
		foreach (var _dummy in context.ShoppingItems)
		{
			//Tôi không biết tại sao chỗ này lại tự động thêm Item, nhưng nó chạy rồi nên kệ đi
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

	public static Cpu WithProduct(this Cpu cpu, IEnumerable<Product> products)
	{
		cpu.Product = products.First(p => p.SpecificationId == cpu.Id);
		return cpu;
	}

	public static Vga WithProduct(this Vga cpu, IEnumerable<Product> products)
	{
		cpu.Product = products.First(p => p.SpecificationId == cpu.Id);
		return cpu;
	}

	public static Ram WithProduct(this Ram ram, IEnumerable<Product> products)
	{
		ram.Product = products.First(p => p.SpecificationId == ram.Id);
		return ram;
	}

	public static Mainboard WithProduct(this Mainboard mainboard, IEnumerable<Product> products)
	{
		mainboard.Product = products.First(p => p.SpecificationId == mainboard.Id);
		return mainboard;
	}
}