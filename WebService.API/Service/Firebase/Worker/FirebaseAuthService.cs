using Firebase.Auth;

namespace WebService.API.Service.Firebase;

public class FirebaseAuthService
{
	private readonly FirebaseAuthClient _firebaseAuth;

	public FirebaseAuthService(FirebaseAuthClient firebaseAuth)
	{
		_firebaseAuth = firebaseAuth;
	}

	public async Task<UserCredential?> SignUp(string email, string password)
	{
		var _userCredentials = await _firebaseAuth.CreateUserWithEmailAndPasswordAsync(email, password);

		return _userCredentials;
	}

	public async Task<UserCredential?> Login(string email, string password)
	{
		var _userCredentials = await _firebaseAuth.SignInWithEmailAndPasswordAsync(email, password);

		return _userCredentials;
	}

	public void SignOut()
	{
		_firebaseAuth.SignOut();
	}
}