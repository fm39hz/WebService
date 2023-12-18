using WebService.API.Virtual.Abstract;

namespace WebService.API.Datas.Models.Users;

public sealed record ShippingInformation : ModelBase
{
	public string? UserUId { get; init; }
	public required string PhoneNumber { get; init; }
	public required string Address { get; init; }
}