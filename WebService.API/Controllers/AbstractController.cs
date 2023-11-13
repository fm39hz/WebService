using WebService.API.Datas.Models;
using WebService.API.Instanced.PromoteStrategy;
using WebService.API.VirtualBase;

namespace WebService.API.Controllers;

public static class AbstractController
{
	public static ISpecifications GetSpec(string type, long id)
	{
		return type switch
		{
			"cpu" => new CpuSpec
			{
				Id = id
			},
			"vga" => new VgaSpec
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