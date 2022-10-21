using System.Collections.Generic;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.Domain.Dto.Base;

namespace ToolBoxDeveloper.DomainContext.Domain.Contracts.Services.Base
{
    public  interface IBaseService<TDto> where TDto : BaseDto
    {
        Task<List<TDto>> GetAll();
        Task AddOrUpdate(TDto dto);
        Task<TDto> Find(string id);
        Task Delete(string id);
    }
}
