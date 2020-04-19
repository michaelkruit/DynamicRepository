using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IDynamicCrud<T>
    {
        Task<T> GetSingle(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetList(Expression<Func<T, bool>> predicate);
        Task<T> Create(T entity);
        Task<T> Update(T enetity);
        Task Delete(T entity);
    }
}
