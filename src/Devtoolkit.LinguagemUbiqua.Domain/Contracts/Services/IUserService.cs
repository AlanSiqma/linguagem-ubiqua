using System.Threading.Tasks;
using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Services.Base;
using Devtoolkit.LinguagemUbiqua.Domain.Dto;

namespace Devtoolkit.LinguagemUbiqua.Domain.Contracts.Services
{
    public interface IUserService : IBaseService<UserDto>
    {
        Task<bool> Autenticate(UserDto dto);
    }
}
