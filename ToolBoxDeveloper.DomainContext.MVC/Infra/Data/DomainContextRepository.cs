using ToolBoxDeveloper.DomainContext.MVC.Domain.Contracts;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Entities;
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
