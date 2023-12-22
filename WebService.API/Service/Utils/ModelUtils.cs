using Microsoft.EntityFrameworkCore;
using WebService.API.Datas.Context;
using WebService.API.Datas.Models.Products;
using WebService.API.Datas.Models.Shopping;
using WebService.API.Virtual.Abstract;

namespace WebService.API.Service;

public static class ModelUtils
{
	public static ShoppingCart WithShoppingItems(this ShoppingCart cart, DataContext context)
	{
		context.ShoppingItems.Load();
		return cart with
		{
			ShoppingItems = cart.ShoppingItems.WithShoppingProduct(context).ToList()
		};
	}

	public static Order WithItems(this Order order, DataContext context)
	{
		context.Orders.Load();
		foreach (var _item in context.ShoppingItems.Where(i => i.OrderId == order.Id))
		{
			order.Items.Add(_item);
		}
		return order with
		{
			User = context.Users.First(u => u.Uid == order.UserUid),
			Invoice = context.Invoices.First(i => i.OrderId == order.Id),
			ShippingTarget = context.ShippingInformations.First(i => i.Id == order.ShippingId)
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