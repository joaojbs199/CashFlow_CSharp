
using CashFlow.Application.UseCases.Expenses;
using CashFlow.Communication.Enums;
using CashFlow.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.tests.Expenses.Register;

public class RegisterExpenseValidatorTests
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("    ")]
    public void ErrorEmptyTitle(string title)
    {
        // Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.title = title;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.Should().Contain(error => error.ErrorMessage.Equals(ErrorMessagesResource.REQUIRED_TITLE));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-7)]
    public void ErrorInvalidAmount(decimal amount)
    {
        // Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.amount = amount;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.Should().Contain(error => error.ErrorMessage.Equals(ErrorMessagesResource.INVALID_AMOUNT));
    }

    [Fact]
    public void ErrorFutureDate()
    {
        // Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.date = DateTime.UtcNow.AddDays(3);

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.Should().Contain(error => error.ErrorMessage.Equals(ErrorMessagesResource.INVALID_DATE));
    }

    [Fact]
    public void ErrorInvalidPaymentType()
    {
        // Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.paymentType = (PaymentType)432;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.Should().Contain(error => error.ErrorMessage.Equals(ErrorMessagesResource.INVALID_PAYMENT_TYPE));
    }

    [Fact]
    public void Success()
    {
        // Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeTrue();
    }
}
