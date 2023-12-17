using System.ComponentModel.DataAnnotations.Schema;
using WebService.API.Datas.Models.Products;

namespace WebService.API.Virtual.Abstract;

public record Product : ModelBase
{
	public string? Name { get; set; }

	public int ConcreateId { get; set; }
	// Other properties

	[ForeignKey("ConcreateId")]
	public Cpu? Cpu { get; set; }

	[ForeignKey("ConcreateId")]
	public Vga? Vga { get; set; }

	public string? Description { get; set; }
	public string? ImageUrl { get; set; }
	public double BasePrice { get; set; }
	public int Quantity { get; set; }
}