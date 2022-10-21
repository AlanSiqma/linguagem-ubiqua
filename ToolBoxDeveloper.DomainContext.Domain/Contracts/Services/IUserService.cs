using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Services.Base;
using ToolBoxDeveloper.DomainContext.Domain.Dto;

namespace ToolBoxDeveloper.DomainContext.Domain.Contracts.Services
{
    public interface IUserService:IBaseService<UserDto>
    {
        Task<bool> Autenticate(UserDto dto);
    }
}
