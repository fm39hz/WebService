using WebService.API.VirtualBase.Abstract;

namespace WebService.API.Datas.Models.Products;

public record ProductSet : ModelBase
{
	public int ProductId { get; set; }
	public int Quantity { get; set; }
}