using Microsoft.AspNetCore.Mvc.Filters;
using CashFlow.Exception.BaseExceptions;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;
using CashFlow.Exception;

namespace CashFlow.Api.Filters;

public class ExceptionFilter: IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is CashFlowException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknownError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var cashFlowException = (CashFlowException)context.Exception;

        var errorResponse = new ResponseErrorJson(cashFlowException.GetErrorMessages());

        context.HttpContext.Response.StatusCode = cashFlowException.statusCode;

        context.Result = new ObjectResult(errorResponse);
    }

    private void ThrowUnknownError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson(ErrorMessagesResource.UNKNOWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        context.Result = new ObjectResult(errorResponse);
    }
}
