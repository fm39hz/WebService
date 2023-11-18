using WebService.API.Datas.Models.Products;
using WebService.API.VirtualBase;

namespace WebService.API.Instanced.PromoteStrategy;

public class NoDiscount : IPromoteStrategy
{
	public string Details
	{
		get { return "Mức giá gốc của sản phẩm"; }
	}

	public double DoDiscount(double basePrice)
	{
		return basePrice;
	}

	public bool CheckCondition(Product product)
	{
		return true;
	}
}