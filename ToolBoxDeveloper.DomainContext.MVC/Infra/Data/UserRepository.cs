using ToolBoxDeveloper.DomainContext.MVC.Domain.Contracts;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Entities;
using ToolBoxDeveloper.DomainContext.MVC.Infra.Data.Base;

namespace ToolBoxDeveloper.DomainContext.MVC.Infra.Data
{
    public class UserRepository: RepositoryBase<UserEntity>, IUserRepository
    {
        public UserRepository(IDatabaseSettings settings):base(settings)
        {

        }
    }
}
