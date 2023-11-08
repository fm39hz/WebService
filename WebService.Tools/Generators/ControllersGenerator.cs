using System.Diagnostics;

namespace WebService.Tools.Generators;

public static class ControllersGenerator
{
	public static string TargetDirectory
	{
		get
		{
			return Directory.GetCurrentDirectory()[..^33] + "WebService.API\\Models";
		}
	}

	public static void Generate()
	{
		var _files = Directory.GetFiles(TargetDirectory, "*DbContext.cs", SearchOption.AllDirectories);
		foreach (var _file in _files)
		{
			var _fileInfo = new FileInfo(_file);

			//Lấy tên Model & Context để tạo Controller
			var _controllerName = string.Concat(_fileInfo.Name[..^12], "sController");
			var _dbContextName = _fileInfo.Name[..^3];
			var _modelName = _fileInfo.Name[..^12];

			//Tạo set argument
			var _codeGenCommand = "aspnet-codegenerator controller -name " + 
				_controllerName + " -async -api -m " + 
				_modelName + " -dc" + 
				_dbContextName + " -outDir Controllers";
			
			//Chạy dotnet
			Process _process = new();
				_process.StartInfo.FileName = "dotnet";
				_process.StartInfo.WorkingDirectory = TargetDirectory[..^6] + "\\";
				_process.StartInfo.Arguments = _codeGenCommand;
				_process.Start();
		}
	}
}