using WebService.API.Datas.Models.Users;
using WebService.API.Virtual.Abstract;

namespace WebService.API.Datas.Models.Shopping;

public sealed record Order : ModelBase
{
	public UserInstance? User { get; init; }
	public ShippingInformation? ShippingTarget { get; init; }
	public List<ShoppingItem>? Items { get; init; } = new();
	public Invoice Invoice { get; init; } = null!;
	public string? UserUid { get; init; }
	public int ShippingId { get; init; }
}