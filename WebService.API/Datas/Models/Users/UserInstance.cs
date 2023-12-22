using WebService.API.Datas.Models.Shopping;

namespace WebService.API.Datas.Models.Users;

public sealed record UserInstance(string Uid)
{
	public string? Credential { get; set; }
	public int IsAdmin { get; init; }
	public ShoppingCart Cart { get; init; } = null!;
	public List<ShippingInformation> ShippingInfomations { get; init; } = new();
	public List<Invoice> Invoices { get; init; } = new();
}