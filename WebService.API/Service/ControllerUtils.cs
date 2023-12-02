namespace WebService.API.Service;

public static class ControllerUtils
{
	public static bool ItemExists(this IQueryable<dynamic> target, int id)
	{
		return target.Any(e => e.Id == id);
	}
}