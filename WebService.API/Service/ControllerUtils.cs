using WebService.API.Virtual.Abstract;

namespace WebService.API.Service;

public static class ControllerUtils
{
	public static bool ItemExists(this IQueryable<ModelBase> target, int id)
	{
		return target.Any(e => e.Id == id);
	}
}