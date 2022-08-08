using ToolBoxDeveloper.DomainContext.Domain.Contracts;
using ToolBoxDeveloper.DomainContext.Domain.Entities;
using ToolBoxDeveloper.DomainContext.MVC.Infra.Data.Base;

namespace ToolBoxDeveloper.DomainContext.MVC.Infra.Data
{
    public class DomainContextRepository: RepositoryBase<DomainContextEntity>, IDomainContextRepository
    {
        public DomainContextRepository(IDatabaseSettings settings):base(settings)
        {

        }
    }
}
