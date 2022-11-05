using AutoMapper;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Notifications;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Repositories;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Services;
using ToolBoxDeveloper.DomainContext.Domain.Dto;
using ToolBoxDeveloper.DomainContext.Domain.Entities;
using ToolBoxDeveloper.DomainContext.Domain.Extensions;
using ToolBoxDeveloper.DomainContext.Services.Base;

namespace ToolBoxDeveloper.DomainContext.Services
{
    public class DomainContextService : BaseService<DomainContextEntity, DomainContextDto>, IDomainContextService
    {
        private readonly IDomainContextRepository _domainContextRepository;
        private readonly IMapper _mapper;
        public DomainContextService(IDomainContextRepository repository, IMapper mapper, INotifier notifier) : base(repository, mapper, notifier)
        {
            this._domainContextRepository = repository;
            this._mapper = mapper;
        }
        public async Task AddOrUpdate(DomainContextDto dto)
        {
            if (dto.Id.IsNullOrEmptyOrWhiteSpace())
                await this.Create(dto);
            else
                await this.Update(dto);
        }
        private async Task Update(DomainContextDto dto)
        {
            DomainContextEntity entity = _mapper.Map<DomainContextEntity>(dto);
            await this._domainContextRepository.Update(dto.Id, entity);
        }

        private async Task Create(DomainContextDto dto)
        {
            DomainContextEntity entity = _mapper.Map<DomainContextEntity>(dto);
            await this._domainContextRepository.Create(entity);
        }
    }
}
