using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Mvc;

namespace WebService.API.Controllers.Users;

[Route("api/Users")]
[ApiController]
public class UserController : ControllerBase
{
	private readonly FirebaseAuth _authService;

	public UserController(FirebaseApp firebaseApp)
	{
		_authService = FirebaseAuth.GetAuth(firebaseApp);
	}

	[HttpGet("{uid}")]
	public async Task<ActionResult<UserRecord>> Get(string uid)
	{
		return await _authService.GetUserAsync(uid);
	}

	[HttpPut("{uid}")]
	public async Task<ActionResult<UserRecord>> Put(string uid, UserRecord user)
	{
		return await _authService.UpdateUserAsync(new UserRecordArgs
		{
			Uid = uid,
			Email = user.Email
		});
	}
}