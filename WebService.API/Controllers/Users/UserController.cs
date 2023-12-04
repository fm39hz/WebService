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

	[HttpGet("{id:alpha}")]
	public async Task<UserRecord> Get(string id)
	{
		return await _authService.GetUserAsync(id);
	}
}