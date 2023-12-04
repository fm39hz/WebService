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

	[HttpGet("{id}")]
	public async Task<ActionResult<UserRecord>> Get(string id)
	{
		var _userRecord = await _authService.GetUserAsync(id);
		return _userRecord;
	}
}