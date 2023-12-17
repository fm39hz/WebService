using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Mvc;
using WebService.API.Datas.Context;

namespace WebService.API.Controllers.Users;

[Route("api/Users/")]
[ApiController]
public class UserController : ControllerBase
{
	private readonly FirebaseAuth _authService;
	private readonly DataContext _context;

	public UserController(FirebaseApp firebaseApp, DataContext context)
	{
		_context = context;
		_authService = FirebaseAuth.GetAuth(firebaseApp);
	}

	[HttpGet("{uid}")]
	public async Task<ActionResult<UserRecord>> Get(string uid)
	{
		return await _authService.GetUserAsync(uid);
	}

	[HttpGet("IsLoggedIn/{uid}")]
	public async Task<ActionResult<bool>> IsLoggedIn(string uid)
	{
		var _user = await _context.Users.FindAsync(uid);
		if (_user is null)
		{
			return NotFound();
		}
		return _user.SignedIn switch
		{
			1 => true,
			_ => false
		};
	}

	[HttpPut("{uid}")]
	public async Task<ActionResult<UserRecord>> Put(string uid, UserRecordArgs user)
	{
		return await _authService.UpdateUserAsync(user);
	}
}