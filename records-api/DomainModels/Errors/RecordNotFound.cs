using FluentResults;

namespace records_api.DomainModels.Errors
{
	public class RecordNotFound(string message) : Error(message)
	{
	}
}
