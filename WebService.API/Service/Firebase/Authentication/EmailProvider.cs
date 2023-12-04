using Firebase.Auth;
using Firebase.Auth.Providers;

namespace WebService.API.Service.Firebase;

public class EmailProvider : FirebaseAuthProvider
{
	public override FirebaseProviderType ProviderType
	{
		get { return FirebaseProviderType.EmailAndPassword; }
	}

	protected override Task<UserCredential> SignInWithCredentialAsync(AuthCredential credential)
	{
		throw new NotImplementedException();
	}

	protected override Task<UserCredential> LinkWithCredentialAsync(string idToken, AuthCredential credential)
	{
		throw new NotImplementedException();
	}
}