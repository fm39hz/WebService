using Firebase.Auth;
using Microsoft.AspNetCore.Mvc;
using WebService.API.Datas.Context;
using WebService.API.Datas.Models.Users;
using WebService.API.Service.Firebase;

namespace WebService.API.Controllers.Authentication;

[Route("api/Auth")]
[ApiController]
public class AuthenticationController : ControllerBase
{
	private readonly FirebaseAuthClient _authClient;
	private readonly DataContext _context;

	public AuthenticationController(FirebaseAuthClient authClient, DataContext context)
	{
		_authClient = authClient;
		_context = context;
	}

	[HttpPost("Signup")]
	public async Task<ActionResult<string>> SignUp(LoginParam param)
	{
		var _userCredentials =
			await _authClient.CreateUserWithEmailAndPasswordAsync(
				param.Email,
				param.Password
				);
		_context.Users.Add(new UserInstance(_userCredentials.User.Uid));
		await _context.SaveChangesAsync();
		return _userCredentials.User.Uid;
	}

	[HttpPost("Login")]
	public async Task<ActionResult<string>> LogIn(LoginParam param)
	{
		var _userCredentials = await _authClient.SignInWithEmailAndPasswordAsync(param.Email, param.Password);
		var _user = await _context.Users.FindAsync(_userCredentials.User.Uid);
		if (_user is not null)
		{
			_user.SignedIn = 1;
		}
		else
		{
			return Problem("Cannot Login, please check your information");
		}
		_context.Users.Update(_user);
		await _context.SaveChangesAsync();
		return _userCredentials.User.Uid;
	}

	[HttpGet("Logout")]
	public ActionResult LogOut()
	{
		_authClient.SignOut();

		return Ok();
	}
}