
using System.Net;

namespace CashFlow.Exception.BaseExceptions;

public class NotFoundException: CashFlowException
{
    public NotFoundException(string message) : base(message) {}

    public override int statusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrorMessages()
    {
        return [Message];
    }
}
