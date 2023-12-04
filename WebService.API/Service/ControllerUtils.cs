using WebService.API.Datas.Context;
using WebService.API.Datas.Models.Products;
using WebService.API.VirtualBase.Abstract;

namespace WebService.API.Service;

public static class ControllerUtils
{
	/// <summary>
	/// Make sure that Products is exist, if not it will create new item to db
	/// </summary>
	/// <param name="context"></param>
	/// <param name="model"></param>
	public static void EnsureProductsExists(this DataContext context, Product model)
	{
		if (!context.Products.Any(a => a.ProductId == model.Id))
		{
			context.Products.Add(new ProductSet
			{
				ProductId = model.Id
			});
		}
	}

	public static bool ItemExists(this IQueryable<ModelBase> target, int id)
	{
		return target.Any(e => e.Id == id);
	}
}