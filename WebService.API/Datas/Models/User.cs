namespace WebService.API.Datas.Models;

public class User
{
	protected User(string userName, string userCredentials)
	{
		UserName = userName;
		UserCredentials = userCredentials;
	}

	public long Id { get; set; }
	protected string UserName { get; private set; }
	protected string UserCredentials { get; private set; }
	public bool CouldAddItem { get; set; } = false;
	public bool CouldUpdateItem { get; set; } = false;
	public bool CouldRemoveItem { get; set; } = false;
}