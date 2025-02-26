using FluentResults;

namespace records_api.DomainModels.Errors
{
	public class Duplicate(string message) : Error(message)
	{
	}
}
