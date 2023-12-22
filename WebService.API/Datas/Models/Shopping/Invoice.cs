using WebService.API.Virtual.Abstract;

namespace WebService.API.Datas.Models.Shopping;

public sealed record Invoice : ModelBase
{
	public string? UserUid { get; init; }
	public int OrderId { get; init; }
	public DateTime CreatedTime { get; init; }
}