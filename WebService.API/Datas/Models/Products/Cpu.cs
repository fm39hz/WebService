using Newtonsoft.Json;
using WebService.API.VirtualBase;

namespace WebService.API.Datas.Models.Products;

public record Cpu : Specification
{
	public Cpu()
	{
		TableName = "Cpus";
	}

	public string? Socket { get; set; }
	public string? Voltage { get; set; }
	public int Core { get; set; }
	public int Thread { get; set; }
	public double Frequency { get; set; }

	public string? Manufacturer { get; set; }


	public override string GetSpec()
	{
		var _specification = new Dictionary<string, dynamic?>
		{
			{ "Id", Id },
			{ "Manufacturer", Manufacturer },
			{ "Socket", Socket },
			{ "Voltage", Voltage },
			{ "Core", Core },
			{ "Thread", Thread },
			{ "Frequency", Frequency }
		};
		#if DEBUG
		Console.WriteLine(JsonConvert.SerializeObject(_specification));
		#endif
		return JsonConvert.SerializeObject(_specification);
	}
}