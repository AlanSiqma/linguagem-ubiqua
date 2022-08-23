using ToolBoxDeveloper.DomainContext.Domain.Contracts.Repositories;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Settings;
using ToolBoxDeveloper.DomainContext.Domain.Entities;
using ToolBoxDeveloper.DomainContext.Infra.Data.Base;

namespace ToolBoxDeveloper.DomainContext.Infra.Data
{
    public class DomainContextRepository: RepositoryBase<DomainContextEntity>, IDomainContextRepository
    {
        public DomainContextRepository(IDatabaseSettings settings):base(settings)
        {

        }
    }
}
