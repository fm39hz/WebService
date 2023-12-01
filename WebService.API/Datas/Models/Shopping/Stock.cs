using WebService.API.Datas.Models.Users;
using WebService.API.VirtualBase;

namespace WebService.API.Datas.Models.Shopping;

public class Stock
{
	private static readonly Stock Instance = new();

	private Stock()
	{
	}

	private List<IProduct> AvailableProducts { get; } = new();

	public static List<IProduct> GetProducts()
	{
		return Instance.AvailableProducts;
	}

	public static void SortProducst()
	{
	}

	private static void AddProducts(IProduct product, User adminCredential)
	{
		if (!adminCredential.CouldAddItem) return;
		Instance.AvailableProducts.Add(product);
	}
}