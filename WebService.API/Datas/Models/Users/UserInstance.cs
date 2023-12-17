using WebService.API.Datas.Models.Shopping;

namespace WebService.API.Datas.Models.Users;

public record UserInstance(string Uid)
{
	public string? Name { get; init; }
	public int IsAdmin { get; init; }
	public int SignedIn { get; set; }
	public ShoppingCart? Cart { get; init; }
	public ShippingInformation? ShippingInfo { get; init; }
}