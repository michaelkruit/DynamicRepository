using Infrastructure.Data;
using Infrastructure.Data.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ExpenseService : DynamicCrud<Expense>, IExpenseService
    {
        public ExpenseService(UserDataDbContext dbContext)
            :base(dbContext)
        {
        }

        public IEnumerable<Expense> GetUserExpenses(int userId, CancellationToken cancellationToken)
        {
            var userExpenses = GetList(x => x.UserId == userId, cancellationToken);

            // map to model
            return userExpenses;
        }

        public async Task<Expense> GetExpense(int id, CancellationToken cancellationToken)
        {
            var expense = await GetSingle(x => x.Id == id, cancellationToken);
            
            // map to model
            return expense;
        }

        public async Task<Expense> CreateExpense(Expense expense, CancellationToken cancellationToken)
        {
            // map to entity
            var created = await Create(expense);

            // map to model
            return created;
        }

        public async Task<Expense> UpdateExpense(int id, Expense expense, CancellationToken cancellationToken)
        {
            var updated = await Update(expense);

            // map to model
            return updated;
        }

        public async Task DeleteExpense(int id, CancellationToken cancellationToken)
        {
            var expense = await GetSingle(x => x.Id == id, cancellationToken);
            await Delete(expense);
        }
    }
}
