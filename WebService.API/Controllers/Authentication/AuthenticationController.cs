using Firebase.Auth;
using Microsoft.AspNetCore.Mvc;
using WebService.API.Datas.Context;
using WebService.API.Datas.Models.Shopping;
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
		_context.Users.Add(new UserInstance(_userCredentials.User.Uid)
		{
			Credential = _userCredentials.User.Credential.IdToken
		});
		_context.ShoppingCarts.Add(new ShoppingCart
		{
			UserUid = _userCredentials.User.Uid
		});
		await _context.SaveChangesAsync();
		return _userCredentials.User.Uid;
	}

	[HttpPost("Login")]
	public async Task<ActionResult<string>> LogIn(LoginParam param)
	{
		var _userCredentials = await _authClient.SignInWithEmailAndPasswordAsync(param.Email, param.Password);
		var _user = await _context.Users.FindAsync(_userCredentials.User.Uid);
		if (_user is null)
		{
			return NotFound();
		}
		_user.Credential = _userCredentials.User.Credential.IdToken;
		_context.Users.Update(_user);
		await _context.SaveChangesAsync();
		return _userCredentials.User.Uid;
	}

	[HttpGet("Logout/{uid}")]
	public async Task<ActionResult> LogOut(string uid)
	{
		_authClient.SignOut();
		var _user = await _context.Users.FindAsync(uid);
		if (_user is null)
		{
			return NotFound();
		}
		_user.Credential = null;
		_context.Users.Update(_user);
		await _context.SaveChangesAsync();
		return Ok();
	}
}