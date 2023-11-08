namespace WebService.Tools.OsWorker;

public static class OsInfo
{
	private static class SupportedOs
	{
		public static readonly Os Window = new()
		{
			Interpreter = "CMD.EXE"
		};
		public static readonly Os Linux = new()
		{
			Interpreter = "bin/bash"
		};
	}

	public static string GetOsInterpreter()
	{
		if (OperatingSystem.IsWindows())
		{
			return SupportedOs.Window.Interpreter;
		}
		if (OperatingSystem.IsLinux())
		{
			return SupportedOs.Linux.Interpreter;
		}
		throw new InvalidOperationException();
	}
}