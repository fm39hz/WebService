namespace WebService.API.Datas.Models;

public class Guest : User
{
	public Guest(string userName, string userCredentials) : base(userName, userCredentials)
	{
	}

	public required ShoppingCart Cart { get; set; }
	public ShippingInformation? ShippingInfo { get; set; }
}