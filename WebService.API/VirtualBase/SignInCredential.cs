namespace WebService.API.VirtualBase;

public sealed record SignInCredential
{
	public required string Email { get; set; }
	public required string Credential { get; set; }
}