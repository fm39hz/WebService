namespace WebService.API.Service.Firebase;

public record LoginParam
{
	public string? Email { get; set; }
	public string? Password { get; set; }
}