using ToolBoxDeveloper.DomainContext.Domain.Contracts;
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
