
namespace CashFlow.Exception.BaseExceptions;

public abstract class CashFlowException : SystemException
{
    protected CashFlowException(string message): base(message){}

    public abstract int statusCode { get; }

    public abstract List<string> GetErrorMessages();

}
