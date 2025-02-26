using FluentResults;

namespace records_api.DomainModels.Errors
{
	public class Validation(string message) : Error(message)
	{
	}
}
