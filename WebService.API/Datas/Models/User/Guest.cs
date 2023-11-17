using WebService.API.VirtualBase;

namespace WebService.API.Datas.Models;

public record Guest : User
{
	public Guest(SignInCredential credential) : base(credential)
	{
	}

	public required ShoppingCart Cart { get; set; }
	public ShippingInformation? ShippingInfo { get; set; }
}