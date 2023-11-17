using WebService.API.VirtualBase;

namespace WebService.API.Instanced.PromoteStrategy;

public class NoDiscount : IPromoteStrategy
{
	public string Details => "Mức giá gốc của sản phẩm";

	public double DoDiscount(double basePrice)
	{
		return basePrice;
	}
}