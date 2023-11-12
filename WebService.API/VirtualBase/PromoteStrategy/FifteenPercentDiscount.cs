namespace WebService.API.VirtualBase.PromoteStrategy;

public class FifteenPercentDiscount : IPromoteStrategy
{
	public double DoDiscount(double basePrice)
	{
		return basePrice - basePrice * 15 / 100;
	}
}