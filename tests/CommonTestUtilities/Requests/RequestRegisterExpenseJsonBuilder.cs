
using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CommonTestUtilities.Requests;

public class RequestRegisterExpenseJsonBuilder
{
    public static RequestExpenseJson Build()
    {
        var faker = new Faker();

        return new RequestExpenseJson
        {
            title = faker.Commerce.ProductName(),
            date = faker.Date.Past(),
            amount = faker.Random.Decimal(min: 1, max: 1000),
            description = faker.Commerce.ProductDescription(),
            paymentType = faker.PickRandom<PaymentType>()
        };
    }
}
