using WebService.API.Instanced.PromoteStrategy;
using WebService.API.Virtual.Interface;

namespace WebService.API.Controllers;

public static class AbstractFactory
{
	public static IPromoteStrategy GetPromote(int strategy)
	{
		return strategy switch
		{
			15 => new FifteenPercentDiscount(),
			_ => new NoDiscount()
		};
	}
}