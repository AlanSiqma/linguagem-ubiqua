using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Repositories;
using ToolBoxDeveloper.DomainContext.Domain.Entities.Base;
using ToolBoxDeveloper.DomainContext.Domain.Specs;

namespace ToolBoxDeveloper.DomainContext.Infra.Data.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        public readonly IMongoCollection<TEntity> _collections;

        private readonly string _dataBaseName = typeof(TEntity).Name;
        public RepositoryBase(IMongoDatabase database)
        {
            this._collections = database.GetCollection<TEntity>(_dataBaseName);
        }

        public async Task<List<TEntity>> Get()
        {
            var list = await this._collections.FindAsync(x => true);
            return list.ToList();
        }
        public async Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
        {
            var list = await this._collections.FindAsync(predicate);
            return list.ToList();
        }

        public async Task<TEntity> Get(string id)
        {
            var entity = await this._collections.FindAsync<TEntity>(RepositorySpec.FindEntityById<TEntity>(id));
            return entity.FirstOrDefault();
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await _collections.InsertOneAsync(entity);
            return entity;
        }

        public async Task Update(string id, TEntity entity)
        {
            await _collections.ReplaceOneAsync(RepositorySpec.FindEntityById<TEntity>(id), entity);
        }

        public async Task Remove(TEntity entity)
        {
            await _collections.DeleteOneAsync(RepositorySpec.FindEntityById<TEntity>(entity.Id));
        }
    }
}