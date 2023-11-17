namespace WebService.API.Datas.Models;

internal enum Permission
{
	Add,
	Update,
	Remove
}

public class Admin : User
{
	public Admin(string userName, string userCredentials) : base(userName, userCredentials)
	{
	}

	private void GrantPermission(User user, Permission permission)
	{
		switch (permission)
		{
			case Permission.Add:
				user.CouldAddItem = true;
				break;
			case Permission.Update:
				user.CouldUpdateItem = true;
				break;
			case Permission.Remove:
				user.CouldRemoveItem = true;
				break;
			default:
				throw new NotSupportedException("Permission not exist");
		}
	}
}