using System.Collections.Generic;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.Domain.Dto;

namespace ToolBoxDeveloper.DomainContext.Domain.Contracts.Services
{
    public interface IDomainContextService
    {
        Task<List<DomainContextDto>> GetAll();
        Task AddOrUpdate(DomainContextDto dto);
        Task<DomainContextDto> Find(string id);
        Task Delete(string id);
    }
}
