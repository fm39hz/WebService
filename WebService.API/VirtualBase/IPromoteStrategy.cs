using WebService.API.Datas.Models.Products;

namespace WebService.API.VirtualBase;

public interface IPromoteStrategy
{
	public string Details { get; }

	public double DoDiscount(double basePrice);

	public bool CheckCondition(Product product);
}