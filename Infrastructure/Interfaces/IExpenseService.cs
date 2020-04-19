using Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IExpenseService : IDynamicCrud<Expense>
    {
        IEnumerable<Expense> GetUserExpenses(int userId, CancellationToken cancellationToken);
        Task<Expense> GetExpense(int id, CancellationToken cancellationToken);
        Task<Expense> CreateExpense(Expense expense, CancellationToken cancellationToken);
        Task<Expense> UpdateExpense(int id, Expense expense, CancellationToken cancellationToken);
        Task DeleteExpense(int id, CancellationToken cancellationToken);
    }
}
