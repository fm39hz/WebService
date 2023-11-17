using WebService.API.Datas.Models;
using WebService.API.VirtualBase;

namespace WebService.API.Instanced.PromoteStrategy;

public class FifteenPercentDiscount : IPromoteStrategy
{
	public string Details => "Giảm giá 15% cho tất cả các sản phẩm";

	protected void ConditionCheck(Product product, double basePrice)
	{

	}
	public double DoDiscount(double basePrice)
	{
		return basePrice - basePrice * 15 / 100;
	}
}