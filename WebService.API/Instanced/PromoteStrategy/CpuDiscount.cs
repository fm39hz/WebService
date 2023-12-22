using WebService.API.Virtual.Abstract;
using WebService.API.Virtual.Interface;

namespace WebService.API.Instanced.PromoteStrategy;

public class CpuDiscount : IPromoteStrategy
{
	public string Details
	{
		get { return "Giảm giá 15% cho tất cả các sản phẩm thuộc loại Cpu"; }
	}

	public string ShortHand
	{
		get { return "15%"; }
	}

	public bool CheckCondition(Product product)
	{
		return product.Type == "Cpu";
	}

	public double DoDiscount(double basePrice)
	{
		return basePrice - basePrice * 15 / 100;
	}
}