using WebService.API.Datas.Models.Products;
using WebService.API.Instanced.PromoteStrategy;
using WebService.API.VirtualBase;

namespace WebService.API.Controllers;

public static class AbstractFactory
{
	public static ISpecifications GetSpecifications(string type, long id)
	{
		return type switch
		{
			"cpu" => new Cpu(id),
			"vga" => new Vga(id),
			_ => throw new InvalidDataException()
		};
	}

	public static IPromoteStrategy GetPromote(int strategy)
	{
		return strategy switch
		{
			15 => new FifteenPercentDiscount(),
			_ => new NoDiscount()
		};
	}
}