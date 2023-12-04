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

	[HttpPost("signup")]
	public async Task<ActionResult<string>> SignUp(LoginParam param)
	{
		var _userCredentials = await _authClient.CreateUserWithEmailAndPasswordAsync(param.Email, param.Password);
		return _userCredentials is null
			? Problem("Login Failed, please check your information")
			: await _userCredentials.User.GetIdTokenAsync();
	}

	[HttpPost("login")]
	public async Task<ActionResult<string>> LogIn(LoginParam param)
	{
		var _userCredentials = await _authClient.SignInWithEmailAndPasswordAsync(param.Email, param.Password);
		return _userCredentials is null? NoContent() : await _userCredentials.User.GetIdTokenAsync();
	}

	[HttpPost("logout")]
	public void LogOut()
	{
		_authClient.SignOut();
	}
}