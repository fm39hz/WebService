using WebService.API.VirtualBase;

namespace WebService.API.Datas.Models.Users;

public record User
{
	protected User(SignInCredential credential)
	{
		Credential = credential;
	}

	public long Id { get; set; }
	protected SignInCredential Credential { get; private set; }
	public bool CouldAddItem { get; set; } = false;
	public bool CouldUpdateItem { get; set; } = false;
	public bool CouldRemoveItem { get; set; } = false;
}