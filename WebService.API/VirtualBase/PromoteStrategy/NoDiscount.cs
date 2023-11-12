namespace WebService.API.VirtualBase.PromoteStrategy;

public class NoDiscount : IPromoteStrategy
{
	public double DoDiscount(double basePrice)
	{
		return basePrice;
	}
}