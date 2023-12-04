using Firebase.Auth;
using Microsoft.AspNetCore.Mvc;
using WebService.API.Service.Firebase;

namespace WebService.API.Controllers.Authentication;

[Route("api/Auth")]
[ApiController]
public class AuthenticationController : ControllerBase
{
	private readonly FirebaseAuthClient _authClient;

	public AuthenticationController(FirebaseAuthClient autchClient)
	{
		_authClient = autchClient;
	}

	[HttpPost("Signup")]
	public async Task<ActionResult<string>> SignUp(LoginParam param)
	{
		var _userCredentials = await _authClient.CreateUserWithEmailAndPasswordAsync(param.Email, param.Password);
		return _userCredentials is null
			? Problem("Cannot Create User, please check your information")
			: await _userCredentials.User.GetIdTokenAsync();
	}

	[HttpPost("Login")]
	public async Task<ActionResult<string>> LogIn(LoginParam param)
	{
		var _userCredentials = await _authClient.SignInWithEmailAndPasswordAsync(param.Email, param.Password);
		return _userCredentials is null
			? Problem("Cannot Login, please check your information")
			: await _userCredentials.User.GetIdTokenAsync();
	}

	[HttpPost("Logout")]
	public void LogOut()
	{
		_authClient.SignOut();
	}
}