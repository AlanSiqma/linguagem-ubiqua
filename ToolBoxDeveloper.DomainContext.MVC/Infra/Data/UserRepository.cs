using ToolBoxDeveloper.DomainContext.Domain.Contracts;
using ToolBoxDeveloper.DomainContext.Domain.Entities;
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
