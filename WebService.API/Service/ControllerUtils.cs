using WebService.API.Datas.Context;
using WebService.API.VirtualBase.Abstract;

namespace WebService.API.Service;

public static class ControllerUtils
{
	/// <summary>
	/// Make sure that Products is exist, if not it will create new item to db
	/// </summary>
	/// <param name="context">Context that has DbSet for Products</param>
	/// <param name="product">the product that relate to Products</param>
	public static void EnsureProductsExists(this DataContext context, Product product)
	{
		if (!context.Products.Any(a => a.ConcreateId == product.Id))
		{
			context.Products.Add(new Product
			{
				ConcreateId = product.Id
			});
		}
	}

	public static bool ItemExists(this IQueryable<ModelBase> target, int id)
	{
		return target.Any(e => e.Id == id);
	}
}