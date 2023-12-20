using Microsoft.EntityFrameworkCore;
using WebService.API.Datas.Models.Products;
using WebService.API.Virtual.Abstract;

namespace WebService.API.Service.Utils;

public static class ControllerUtils
{
	public static void RemoveProduct(this DbSet<Product> products, Cpu cpu)
	{
		products.Remove(cpu.WithProduct(products).Product!);
	}

	public static void RemoveProduct(this DbSet<Product> products, Vga vga)
	{
		products.Remove(vga.WithProduct(products).Product!);
	}

	public static bool ItemExists(this IQueryable<ModelBase> target, int id)
	{
		return target.Any(e => e.Id == id);
	}
}