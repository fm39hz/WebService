using WebService.API.VirtualBase.Abstract;

namespace WebService.API.VirtualBase.Interface;

public interface IPromoteStrategy
{
	public string Details { get; }

	public double DoDiscount(double basePrice);

	public bool CheckCondition(Product product);
}