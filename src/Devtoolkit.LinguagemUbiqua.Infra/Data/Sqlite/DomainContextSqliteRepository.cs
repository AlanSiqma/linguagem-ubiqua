using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Repositories;
using Devtoolkit.LinguagemUbiqua.Domain.Entities;
using Devtoolkit.LinguagemUbiqua.Infra.Data.Sqlite.Base;
using Devtoolkit.LinguagemUbiqua.Infra.Data.Sqlite.Context;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Devtoolkit.LinguagemUbiqua.Infra.Data.Sqlite
{
    [ExcludeFromCodeCoverage]
    public class DomainContextSqliteRepository : RepositoryBase<DomainContextEntity>, IDisposable, IDomainContextRepository
    {
        public DomainContextSqliteRepository(AppDbContext database) : base(database)
        {
        }

    }
}