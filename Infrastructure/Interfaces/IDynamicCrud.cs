using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IDynamicCrud<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Get list
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        /// <summary>
        /// Get single
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        /// <summary>
        /// Create new
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> Create(TEntity entity);
        /// <summary>
        /// Update existing
        /// </summary>
        /// <param name="enetity"></param>
        /// <returns></returns>
        Task<TEntity> Update(TEntity enetity);
        /// <summary>
        /// Delete 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Delete(TEntity entity);
    }
}
