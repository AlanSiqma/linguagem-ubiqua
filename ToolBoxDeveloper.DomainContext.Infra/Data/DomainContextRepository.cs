using MongoDB.Driver;
using System.Diagnostics.CodeAnalysis;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Repositories;
using ToolBoxDeveloper.DomainContext.Domain.Entities;
using ToolBoxDeveloper.DomainContext.Infra.Data.Base;

namespace ToolBoxDeveloper.DomainContext.Infra.Data
{
    [ExcludeFromCodeCoverage]
    public class DomainContextRepository: RepositoryBase<DomainContextEntity>, IDomainContextRepository
    {
        public DomainContextRepository(IMongoDatabase database) :base(database)
        {
        }
    }
}
