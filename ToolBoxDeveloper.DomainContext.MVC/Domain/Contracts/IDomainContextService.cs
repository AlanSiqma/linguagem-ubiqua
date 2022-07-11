using System.Collections.Generic;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Dto;

namespace ToolBoxDeveloper.DomainContext.MVC.Domain.Contracts
{
    public interface IDomainContextService
    {
        Task<List<DomainContextDto>> GetAll();
        Task AddOrUpdate(DomainContextDto dto);
        Task<DomainContextDto> Find(string id);
        Task<bool> Delete(string id);
    }
}
