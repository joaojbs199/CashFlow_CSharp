using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses;

public class ExpenseValidator : AbstractValidator<RequestExpenseJson>
{
    public ExpenseValidator()
    {
        RuleFor(expense => expense.title).NotEmpty().WithMessage(ErrorMessagesResource.REQUIRED_TITLE);
        RuleFor(expense => expense.date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ErrorMessagesResource.INVALID_DATE);
        RuleFor(expense => expense.amount).GreaterThan(0).WithMessage(ErrorMessagesResource.INVALID_AMOUNT);
        RuleFor(expense => expense.paymentType).IsInEnum().WithMessage(ErrorMessagesResource.INVALID_PAYMENT_TYPE);
    }
}
