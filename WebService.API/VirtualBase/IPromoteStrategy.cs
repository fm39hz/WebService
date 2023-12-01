namespace WebService.API.VirtualBase;

public interface IPromoteStrategy
{
	public string Details { get; }

	public float DoDiscount(float basePrice);

	public bool CheckCondition(IProduct product);
}