using FirebaseAdmin.Auth;

namespace WebService.API.VirtualBase.Abstract;

public abstract record UserBase(IUserInfo UserInfo)
{
	public string? Name { get; set; }
}