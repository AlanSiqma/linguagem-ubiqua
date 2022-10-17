using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ToolBoxDeveloper.DomainContext.Domain.Contracts.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<List<TEntity>> Get();
        Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Get(string id);
        Task<TEntity> Create(TEntity entity);
        Task Update(string id, TEntity entity);
        Task Remove(TEntity entity);
    }
}
