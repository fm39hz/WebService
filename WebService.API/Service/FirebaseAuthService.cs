using Firebase.Auth;

namespace WebService.API.Service;

public sealed class FirebaseAuthService
{
	private FirebaseAuthService()
	{
		Instance.Client = new(new FirebaseAuthConfig
		{
			ApiKey = "",
			AuthDomain = ""
		});
	}

	private static FirebaseAuthService Instance { get; } = new();
	private FirebaseAuthClient Client { get; set; }

	public static async Task<string?> SignUp(string email, string password)
	{
		var _userCredentials = await Instance.Client.CreateUserWithEmailAndPasswordAsync(email, password);
		return _userCredentials is null? null : await _userCredentials.User.GetIdTokenAsync();
	}

	public static async Task<string?> Login(string email, string password)
	{
		var _userCredentials = await Instance.Client.SignInWithEmailAndPasswordAsync(email, password);
		return _userCredentials is null? null : await _userCredentials.User.GetIdTokenAsync();
	}

	public static void SignOut()
	{
		Instance.Client.SignOut();
	}
}