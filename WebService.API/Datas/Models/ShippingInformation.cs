namespace WebService.API.Datas.Models;

public record ShippingInformation
{
	public long UserId { get; set; }
	public required string PhoneNumber { get; set; }
	public required string Address { get; set; }
}