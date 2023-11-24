using WebService.API.Datas.Context;
using WebService.API.Datas.Models.Products;
using WebService.API.Instanced.PromoteStrategy;
using WebService.API.VirtualBase;

namespace WebService.API.Controllers;

public static class AbstractFactory
{
	public static Specification GetSpecs(long id, DataContext context)
	{
		var _type = new SpecController(context).GetId(id).Result;
		return _type.Value switch
		{
			"cpu" => new Cpu
			{
				Id = id
			},
			"vga" => new Vga
			{
				Id = id
			},
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