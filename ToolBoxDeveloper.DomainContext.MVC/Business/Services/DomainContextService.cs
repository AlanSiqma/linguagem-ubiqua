using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Contracts;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Dto;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Entities;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Extensions;

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
            if (dto.Id.IsNullOrEmptyOrWhiteSpace())
                await this.Create(dto);
            else
                await this.Update(dto);
        }

        public async Task<List<DomainContextDto>> GetAll()
        {
            return _mapper.Map<List<DomainContextDto>>(await this._domainContextRepository.Get());
        }

        public async Task<DomainContextDto> Find(string id)
        {
            return _mapper.Map<DomainContextDto>(await this.FindEntityById(id));
        }

        public async Task Delete(string id)
        {
            await this._domainContextRepository.Remove(await this.FindEntityById(id));
        }

        private async Task<DomainContextEntity> FindEntityById(string id)
        {
            if (id.IsNullOrEmptyOrWhiteSpace())
                throw new ArgumentException("Campo id é obrigatorio");

            return (await this._domainContextRepository.Get(x => x.Id.Equals(id))).FirstOrDefault();
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
