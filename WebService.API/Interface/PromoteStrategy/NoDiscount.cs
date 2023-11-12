namespace WebService.API.Interface.PromoteStrategy;

public class NoDiscount : IPromoteStrategy
{
	public double DoDiscount(double basePrice)
	{
		return basePrice;
	}
}