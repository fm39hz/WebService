using WebService.API.Virtual.Abstract;

namespace WebService.API.Virtual.Interface;

public interface IPromoteStrategy
{
	public string Details { get; }

	public double DoDiscount(double basePrice);

	public bool CheckCondition(Product product);
}