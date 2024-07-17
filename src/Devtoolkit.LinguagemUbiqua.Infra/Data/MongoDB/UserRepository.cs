using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Repositories;
using Devtoolkit.LinguagemUbiqua.Domain.Entities;
using Devtoolkit.LinguagemUbiqua.Infra.Data.Base;
using MongoDB.Driver;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Devtoolkit.LinguagemUbiqua.Infra.Data
{
    [ExcludeFromCodeCoverage]
    public class UserRepository : RepositoryBase<UserEntity>, IDisposable, IUserRepository
    {
        public UserRepository(IMongoDatabase database) : base(database)
        {
        }
    }
}