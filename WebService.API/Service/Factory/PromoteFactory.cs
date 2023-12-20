using WebService.API.Instanced.PromoteStrategy;
using WebService.API.Virtual.Interface;

namespace WebService.API.Service.Factory;

public static class PromoteFactory
{
	public static IPromoteStrategy Create(string strategy)
	{
		return strategy switch
		{
			"Cpu" => new CpuDiscount(),
			"Vga" => new VgaDiscount(),
			_ => new NoDiscount()
		};
	}
}