using WebService.API.Virtual.Abstract;

namespace WebService.API.Datas.Models.Shopping;

public record ShoppingCart : ModelBase
{
	public string? UserUid { get; init; }
	public virtual List<ShoppingItem> ShoppingItems { get; set; } = new();

	public double GetFinalPrice()
	{
		return (ShoppingItems ?? throw new InvalidOperationException())
		.Sum(items => items.IsSelected == 1? items.GetFinalPrice() : 0);
	}
}