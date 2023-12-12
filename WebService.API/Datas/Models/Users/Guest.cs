using FirebaseAdmin.Auth;
using WebService.API.Datas.Models.Shopping;
using WebService.API.VirtualBase.Abstract;

namespace WebService.API.Datas.Models.Users;

public record Guest(IUserInfo UserInfo) : UserBase(UserInfo)
{
	public required ShoppingCart Cart { get; set; }
	public ShippingInformation? ShippingInfo { get; set; }
}