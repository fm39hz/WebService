using Newtonsoft.Json;
using WebService.API.VirtualBase;

namespace WebService.API.Datas.Models.Products;

public record Vga : Specification
{
	public double Frequency { get; set; }
	public int Vram { get; set; }
	public string? Manufacturer { get; set; }

	public override string GetSpec()
	{
		var _specification = new Dictionary<string, dynamic?>
		{
			{ "Id", Id },
			{ "Manufacturer", Manufacturer },
			{ "Frequency", Frequency },
			{ "Vram", Vram }
		};
		return JsonConvert.SerializeObject(_specification);
	}
}