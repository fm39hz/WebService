using WebService.API.Virtual.Abstract;

namespace WebService.API.Datas.Models.Users;

public sealed record ShippingInformation : ModelBase
{
	public string? UserUId { get; init; }
	public string? Name { get; init; }
	public string? PhoneNumber { get; init; }
	public string? Address { get; init; }
	public string? Gender { get; init; }
}