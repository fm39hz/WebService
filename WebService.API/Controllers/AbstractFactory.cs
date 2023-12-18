using WebService.API.Instanced.PromoteStrategy;
using WebService.API.Virtual.Interface;

namespace WebService.API.Controllers;

public static class AbstractFactory
{
	public static IPromoteStrategy GetPromote(string strategy)
	{
		return strategy switch
		{
			"Cpu" => new CpuDiscount(),
			"Vga" => new VgaDiscount(),
			_ => new NoDiscount()
		};
	}
}