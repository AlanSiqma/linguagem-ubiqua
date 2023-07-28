using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Repositories;
using Devtoolkit.LinguagemUbiqua.Domain.Entities.Base;
using Devtoolkit.LinguagemUbiqua.Domain.Specs;

namespace Devtoolkit.LinguagemUbiqua.Infra.Data.Base
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        private readonly IMongoCollection<TEntity> _collection;

        public RepositoryBase(IMongoDatabase database)
        {
            string collectionName = typeof(TEntity).Name;
            _collection = database.GetCollection<TEntity>(collectionName);
        }

        public async Task<List<TEntity>> Get()
        {
            var list = await _collection.FindAsync(x => true);
            return list.ToList();
        }

        public async Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
        {
            var list = await _collection.FindAsync(predicate);
            return list.ToList();
        }

        public async Task<TEntity> Get(string id)
        {
            var entity = await _collection.FindAsync<TEntity>(RepositorySpec.FindEntityById<TEntity>(id));
            return entity.FirstOrDefault();
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task Update(string id, TEntity entity)
        {
            await _collection.ReplaceOneAsync(RepositorySpec.FindEntityById<TEntity>(id), entity);
        }

        public async Task Remove(TEntity entity)
        {
            await _collection.DeleteOneAsync(RepositorySpec.FindEntityById<TEntity>(entity.Id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
