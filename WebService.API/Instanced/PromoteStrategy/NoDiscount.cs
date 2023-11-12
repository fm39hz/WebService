using WebService.API.VirtualBase;

namespace WebService.API.Instanced.PromoteStrategy;

public class NoDiscount : IPromoteStrategy
{
	public double DoDiscount(double basePrice)
	{
		return basePrice;
	}
}