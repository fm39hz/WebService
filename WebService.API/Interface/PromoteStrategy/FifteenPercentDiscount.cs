namespace WebService.API.Interface.PromoteStrategy;

public class FifteenPercentDiscount : IPromoteStrategy
{
	public double DoDiscount(double basePrice)
	{
		return basePrice - basePrice * 15 / 100;
	}
}