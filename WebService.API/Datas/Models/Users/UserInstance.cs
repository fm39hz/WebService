using WebService.API.Datas.Models.Shopping;

namespace WebService.API.Datas.Models.Users;

public record UserInstance(string Uid)
{
	public string? Credential { get; set; }
	public int IsAdmin { get; init; }
	public ShoppingCart? Cart { get; init; }
	public ShippingInformation? ShippingInfo { get; init; }
}