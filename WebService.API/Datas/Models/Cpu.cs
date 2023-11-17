using Newtonsoft.Json;
using WebService.API.VirtualBase;

namespace WebService.API.Datas.Models;

public record Cpu : ISpecifications
{
	public string? Socket { get; set; }
	public string? Voltage { get; set; }
	public int Core { get; set; }
	public int Thread { get; set; }
	public double Frequency { get; set; }
	public required long Id { get; set; }
	public string? Brand { get; set; }

	public string GetSpec()
	{
		var props = new Dictionary<string, dynamic?>()
		{
			{"Id", Id},
			{"Brand", Brand},
			{"Socket", Socket},
			{"Voltage", Voltage},
			{"Core", Core},
			{"Thread", Thread},
			{"Frequency", Frequency}
		};
#if DEBUG
		Console.WriteLine(JsonConvert.SerializeObject(props));
#endif
		return JsonConvert.SerializeObject(props);
	}
}