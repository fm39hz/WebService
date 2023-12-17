using WebService.API.VirtualBase.Abstract;

namespace WebService.API.Datas.Models.Users;

public sealed record ShippingInformation : ModelBase
{
	public long UserId { get; set; }
	public required string PhoneNumber { get; set; }
	public required string Address { get; set; }
}