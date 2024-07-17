using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Repositories;
using Devtoolkit.LinguagemUbiqua.Domain.Entities;
using Devtoolkit.LinguagemUbiqua.Infra.Data.Base;
using MongoDB.Driver;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Devtoolkit.LinguagemUbiqua.Infra.Data
{
    [ExcludeFromCodeCoverage]
    public class DomainContextRepository : RepositoryBase<DomainContextEntity>, IDisposable, IDomainContextRepository
    {
        public DomainContextRepository(IMongoDatabase database) : base(database)
        {
        }

    }
}