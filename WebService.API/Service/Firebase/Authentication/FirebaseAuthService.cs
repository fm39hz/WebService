using Firebase.Auth;

namespace WebService.API.Service.Firebase;

public class FirebaseAuthService
{
	private readonly FirebaseAuthClient _firebaseAuth;

	public FirebaseAuthService(FirebaseAuthClient firebaseAuth)
	{
		_firebaseAuth = firebaseAuth;
	}

	public async Task<string?> SignUp(string email, string password)
	{
		var _userCredentials = await _firebaseAuth.CreateUserWithEmailAndPasswordAsync(email, password);
		return _userCredentials is null? null : await _userCredentials.User.GetIdTokenAsync();
	}

	public async Task<string?> Login(string email, string password)
	{
		var _userCredentials = await _firebaseAuth.SignInWithEmailAndPasswordAsync(email, password);
		return _userCredentials is null? null : await _userCredentials.User.GetIdTokenAsync();
	}

	public void SignOut()
	{
		_firebaseAuth.SignOut();
	}
}