namespace WebService.API.VirtualBase.Interface;

public abstract record UserInformation(string Id)
{
	public string? Name { get; set; }
}