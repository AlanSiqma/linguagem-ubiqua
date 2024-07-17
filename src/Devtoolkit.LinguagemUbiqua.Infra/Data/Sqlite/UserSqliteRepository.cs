using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Repositories;
using Devtoolkit.LinguagemUbiqua.Domain.Entities;
using Devtoolkit.LinguagemUbiqua.Infra.Data.Sqlite.Base;
using Devtoolkit.LinguagemUbiqua.Infra.Data.Sqlite.Context;
using MongoDB.Driver;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Devtoolkit.LinguagemUbiqua.Infra.Data.Sqlite
{
    [ExcludeFromCodeCoverage]
    public class UserSqliteRepository : RepositoryBase<UserEntity>, IDisposable, IUserRepository
    {
        public UserSqliteRepository(AppDbContext database) : base(database)
        {
        }
    }
}