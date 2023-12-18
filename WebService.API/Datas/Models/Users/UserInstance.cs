using WebService.API.Datas.Models.Shopping;

namespace WebService.API.Datas.Models.Users;

public record UserInstance(string Uid)
{
	public string? Credential { get; set; }
	public int IsAdmin { get; init; }
	public virtual ShoppingCart? Cart { get; init; }
	public virtual ShippingInformation? ShippingInfo { get; init; }
}