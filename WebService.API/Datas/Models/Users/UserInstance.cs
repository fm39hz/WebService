using WebService.API.Datas.Models.Shopping;

namespace WebService.API.Datas.Models.Users;

public record UserInstance(string Uid)
{
	public string? Name { get; init; }
	public bool IsAdmin { get; init; }
	public ShoppingCart? Cart { get; init; }
	public ShippingInformation? ShippingInfo { get; init; }
}