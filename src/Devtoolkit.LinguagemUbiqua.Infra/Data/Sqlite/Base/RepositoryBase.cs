using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Repositories;
using Devtoolkit.LinguagemUbiqua.Domain.Entities.Base;
using Devtoolkit.LinguagemUbiqua.Domain.Specs;
using Devtoolkit.LinguagemUbiqua.Infra.Data.Sqlite.Context;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Devtoolkit.LinguagemUbiqua.Infra.Data.Sqlite.Base
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        public DbContext _context = null;
        public DbSet<TEntity> _entity = null;

        public RepositoryBase(AppDbContext database)
        {
            _context = database;
            _entity = _context.Set<TEntity>();
        }

        public async Task<List<TEntity>> Get()
        {
           try
            {
                return await _entity.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await _entity.Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<TEntity> Get(string id)
        {
            try
            {
                return await _entity.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            try
            {
                _entity.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task Update(string id, TEntity entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task Remove(TEntity entity)
        {
            try
            {
                _entity.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
