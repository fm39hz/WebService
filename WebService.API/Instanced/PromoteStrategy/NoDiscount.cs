using WebService.API.Virtual.Abstract;
using WebService.API.Virtual.Interface;

namespace WebService.API.Instanced.PromoteStrategy;

public class NoDiscount : IPromoteStrategy
{
	public string Details
	{
		get { return "Không có chương trình khuyến mại nào được áp dụng"; }
	}

	public string ShortHand
	{
		get { return "NoDiscount"; }
	}

	public double DoDiscount(double basePrice)
	{
		return basePrice;
	}

	public bool CheckCondition(Product product)
	{
		return true;
	}
}