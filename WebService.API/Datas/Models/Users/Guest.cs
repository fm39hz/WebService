using WebService.API.Datas.Models.Shopping;
using WebService.API.Service.Firebase;

namespace WebService.API.Datas.Models.Users;

public record Guest : User
{
	public Guest(SignInCredential credential) : base(credential)
	{
	}

	public required ShoppingCart Cart { get; set; }
	public ShippingInformation? ShippingInfo { get; set; }
}