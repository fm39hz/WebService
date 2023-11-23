using Newtonsoft.Json;
using WebService.API.VirtualBase;

namespace WebService.API.Datas.Models.Products;

public record Vga : Specifications
{
	public Vga(long id) : base(id)
	{
		Type = "vga";
	}

	public double Frequency { get; set; }
	public int Vram { get; set; }
	public string? Brand { get; set; }

	public string GetSpec()
	{
		var _specification = new Dictionary<string, dynamic?>
		{
			{ "Id", Id },
			{ "Brand", Brand },
			{ "Frequency", Frequency },
			{ "Vram", Vram }
		};
		return JsonConvert.SerializeObject(_specification);
	}
}