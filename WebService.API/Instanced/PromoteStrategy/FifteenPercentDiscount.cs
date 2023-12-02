using WebService.API.VirtualBase;

namespace WebService.API.Instanced.PromoteStrategy;

public class FifteenPercentDiscount : IPromoteStrategy
{
	public string Details
	{
		get { return "Giảm giá 15% cho tất cả các sản phẩm"; }
	}

	public bool CheckCondition(Product product)
	{
		return true;
	}

	public double DoDiscount(double basePrice)
	{
		return basePrice - basePrice * 15 / 100;
	}
}