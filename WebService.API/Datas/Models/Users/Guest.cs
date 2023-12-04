using WebService.API.Datas.Models.Shopping;
using WebService.API.VirtualBase.Interface;

namespace WebService.API.Datas.Models.Users;

public record Guest(string Id) : UserInformation(Id)
{
	public required ShoppingCart Cart { get; set; }
	public ShippingInformation? ShippingInfo { get; set; }
}