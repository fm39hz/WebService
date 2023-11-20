using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebService.API.Controllers;
using WebService.API.VirtualBase;

namespace WebService.API.Service;

public class SpecificationConverter : ValueConverter<ISpecifications, long>
{
	public SpecificationConverter(string type) : base(
		specifications => specifications.Id,
		id => AbstractFactory.GetSpecifications(type, id))
	{
	}
}