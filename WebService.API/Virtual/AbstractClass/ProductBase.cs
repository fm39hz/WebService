namespace WebService.API.Virtual.Abstract;

public abstract record ProductBase : ModelBase
{
	public Product? Product { get; set; }
}