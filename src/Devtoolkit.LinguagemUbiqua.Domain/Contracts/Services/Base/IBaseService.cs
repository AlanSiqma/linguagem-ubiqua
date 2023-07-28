using System.Collections.Generic;
using System.Threading.Tasks;
using Devtoolkit.LinguagemUbiqua.Domain.Dto.Base;

namespace Devtoolkit.LinguagemUbiqua.Domain.Contracts.Services.Base
{
    public interface IBaseService<TDto> where TDto : BaseDto
    {
        Task<List<TDto>> GetAll();
        Task AddOrUpdate(TDto dto);
        Task<TDto> Find(string id);
        Task Delete(string id);
    }
}
