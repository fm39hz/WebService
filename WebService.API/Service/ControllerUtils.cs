using WebService.API.Datas.Context;
using WebService.API.Datas.Models.Products;
using WebService.API.VirtualBase.Abstract;

namespace WebService.API.Service;

public static class ControllerUtils
{
	/// <summary>
	/// Make sure that Products is exist, if not it will create new item to db
	/// </summary>
	/// <param name="context">Context that has DbSet for ProductSet</param>
	/// <param name="product">the product that relate to ProductSet</param>
	public static void EnsureProductsExists(this DataContext context, Product product)
	{
		if (!context.Products.Any(a => a.ProductId == product.Id))
		{
			context.Products.Add(new ProductSet
			{
				ProductId = product.Id
			});
		}
	}

	public static bool ItemExists(this IQueryable<ModelBase> target, int id)
	{
		return target.Any(e => e.Id == id);
	}
}