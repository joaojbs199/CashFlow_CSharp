
using CashFlow.Communication.Enums;

namespace CashFlow.Communication.Requests;

public class RequestExpenseJson
{
    public string title { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
    public DateTime date { get; set; }
    public decimal amount { get; set; }
    public PaymentType paymentType { get; set; }
}
