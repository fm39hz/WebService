using WebService.API.Datas.Models.Products;
using WebService.API.Datas.Models.Users;

namespace WebService.API.Datas.Models.Shopping;

public class Stock
{
	private static readonly Stock Instance = new();

	private Stock()
	{
	}

	private List<Admin> Admins { get; } = new();
	private List<Product> AvailableProducts { get; } = new();

	public static List<Product> GetProducts()
	{
		return Instance.AvailableProducts;
	}

	public static void SortProducst()
	{
	}

	private static void AddProducts(Product product, Admin adminCredential)
	{
		if (!Instance.Admins.Any(admin => admin == adminCredential && admin.CouldAddItem)) return;
		Instance.AvailableProducts.Add(product);
	}
}