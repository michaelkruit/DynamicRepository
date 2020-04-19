using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DynamicCrud<TEntity> : IDynamicCrud<TEntity>
        where TEntity : class
    {
        private readonly UserDataDbContext _dbContext;
        public DynamicCrud(UserDataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            var tResult = _dbContext.Set<TEntity>().Where(predicate);
            return tResult;
        }

        public async Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            var tEntity = await _dbContext.Set<TEntity>().SingleOrDefaultAsync(predicate, cancellationToken);
            return tEntity;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
