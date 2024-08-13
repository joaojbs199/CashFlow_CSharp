
using System.Net;

namespace CashFlow.Exception.BaseExceptions;

public class ValidationException: CashFlowException
{
    private readonly List<string> _errorMessages;

    public ValidationException(List<string> errorMessages): base(string.Empty)
    {
        _errorMessages = errorMessages;
    }
    public override int statusCode => (int)HttpStatusCode.BadRequest;

    public override List<string> GetErrorMessages()
    {
        return _errorMessages;
    }
}
