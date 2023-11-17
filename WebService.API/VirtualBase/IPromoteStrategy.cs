using WebService.API.Datas.Models;

namespace WebService.API.VirtualBase;

public interface IPromoteStrategy
{
	public string Details { get; }
	public double DoDiscount(double basePrice);
	protected bool ConditionCheck(Product product, double basePrice);
}