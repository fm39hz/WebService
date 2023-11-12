using WebService.Tools.Generators;

namespace WebService.Tools.AutoRunner;

public static class AutoRunner
{
	public static void Main()
	{
		ControllersGenerator.Generate();
	}
}
