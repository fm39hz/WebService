using WebService.API.VirtualBase;

namespace WebService.API.Datas.Models;

internal enum Permission
{
	Add,
	Update,
	Remove
}

public record Admin : User
{
	public Admin(SignInCredential credential) : base(credential)
	{
	}

	private static void GrantPermission(User user, Permission permission)
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