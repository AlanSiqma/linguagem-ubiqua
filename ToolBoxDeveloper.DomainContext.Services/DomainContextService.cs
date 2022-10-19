using AutoMapper;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Notifications;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Repositories;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Services;
using ToolBoxDeveloper.DomainContext.Domain.Dto;
using ToolBoxDeveloper.DomainContext.Domain.Entities;
using ToolBoxDeveloper.DomainContext.Services.Base;

namespace ToolBoxDeveloper.DomainContext.Services
{
    public class DomainContextService : BaseService<DomainContextEntity, DomainContextDto>, IDomainContextService
    {

        public DomainContextService(IDomainContextRepository repository,IMapper mapper,INotifier notifier) : base(repository, mapper, notifier)
        {
        }
    }
}
