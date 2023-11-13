using WebService.API.VirtualBase;

namespace WebService.API.Instanced.PromoteStrategy;

public class FifteenPercentDiscount : IPromoteStrategy
{
	public double DoDiscount(double basePrice)
	{
		return basePrice - basePrice * 15 / 100;
	}
}