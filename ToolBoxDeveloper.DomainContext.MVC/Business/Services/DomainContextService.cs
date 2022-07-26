using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Contracts;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Dto;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Entities;

namespace ToolBoxDeveloper.DomainContext.MVC.Business.Services
{
    public class DomainContextService : IDomainContextService
    {
        private readonly ILogger<DomainContextService> _logger;
        private readonly IDomainContextRepository _domainContextRepository;
        public readonly IMapper _mapper;
        public DomainContextService(IDomainContextRepository domainContextRepository, ILogger<DomainContextService> logger, IMapper mapper)
        {
            this._domainContextRepository = domainContextRepository;
            this._logger = logger;
            this._mapper = mapper;
        }

        public async Task AddOrUpdate(DomainContextDto dto)
        {
            if (string.IsNullOrEmpty(dto.Id))
                await Create(dto);
            else
                await Update(dto);
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

        public async Task Delete(string id)
        {
            var entity = (await this._domainContextRepository.Get(x => x.Id.Equals(id))).FirstOrDefault();

            await this._domainContextRepository.Remove(entity);
        }

        public async Task<DomainContextDto> Find(string id)
        {
            var entity = (await this._domainContextRepository.Get(x => x.Id.Equals(id))).FirstOrDefault();
            DomainContextDto dto = _mapper.Map<DomainContextDto>(entity);
            return dto;
        }

        public async Task<List<DomainContextDto>> GetAll()
        {
            var entities = await this._domainContextRepository.Get();
            List<DomainContextDto> listDto = _mapper.Map<List<DomainContextDto>>(entities);
            return listDto;
        }
    }
}
