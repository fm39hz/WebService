namespace WebService.API.Models;

public class Cpu : Item
{
	public required string Socket { get; set; }

	public Cpu()
	{
		ItemsType = "Cpu";
	}
}