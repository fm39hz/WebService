using WebService.API.Virtual.Abstract;
using WebService.API.Virtual.Interface;

namespace WebService.API.Instanced.PromoteStrategy;

public class VgaDiscount : IPromoteStrategy
{
	public string Details
	{
		get { return "Giảm giá 35% cho tất cả các sản phẩm thuộc loại Vga"; }
	}

	public string ShortHand
	{
		get { return "35%"; }
	}

	public double DoDiscount(double basePrice)
	{
		return basePrice - basePrice * 35 / 100;
	}

	public bool CheckCondition(Product product)
	{
		return product.Type == "Vga";
	}
}