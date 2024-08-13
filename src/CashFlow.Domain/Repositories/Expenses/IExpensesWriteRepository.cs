using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;
public interface IExpensesWriteRepository
{
    Task Add(Expense expense);
    /// <summary>
    /// This method returns true if occurrs success delete; Otherwise returns false.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> Delete(long id);
}
