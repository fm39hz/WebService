using WebService.API.VirtualBase;

namespace WebService.API.Instanced.PromoteStrategy;

public class NoDiscount : IPromoteStrategy
{
	public string Details
	{
		get { return "Mức giá gốc của sản phẩm"; }
	}

	public float DoDiscount(float basePrice)
	{
		return basePrice;
	}

	public bool CheckCondition(IProduct product)
	{
		return true;
	}
}