using WebService.API.Datas.Context;
using WebService.API.Datas.Models.Products;
using WebService.API.Instanced.PromoteStrategy;
using WebService.API.VirtualBase;

namespace WebService.API.Controllers;

public static class AbstractFactory
{
	public static Specification GetSpecs(long id, Product target, DataContext context)
	{
		return context.Products.Find(target.Id).SpecificationInfo.TableName switch
		{
			"Cpus" => new Cpu
			{
				Id = id,
				ProductTarget = target
			},
			"Vgas" => new Vga
			{
				Id = id,
				ProductTarget = target
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