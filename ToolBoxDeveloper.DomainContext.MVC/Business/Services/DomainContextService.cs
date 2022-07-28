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
            if (string.IsNullOrEmpty(dto.Id))
                await Create(dto);
            else
                await Update(dto);
        }

        public async Task<List<DomainContextDto>> GetAll()
        {
            return _mapper.Map<List<DomainContextDto>>(await this._domainContextRepository.Get());
        }

        public async Task<DomainContextDto> Find(string id)
        {
            if (this.IsInvalidId(id))
                throw new ArgumentException("Campo id é obrigatorio");

            return _mapper.Map<DomainContextDto>(await this.FindEntity(id));
        }

        public async Task Delete(string id)
        {
            if (this.IsInvalidId(id))
                throw new ArgumentException("Campo id é obrigatorio");

            await this._domainContextRepository.Remove(await this.FindEntity(id));
        }

        private async Task<DomainContextEntity> FindEntity(string id)
        {
            var listEntity = await this._domainContextRepository.Get(x => x.Id.Equals(id));
            return listEntity.FirstOrDefault();
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

        private bool IsInvalidId(string id)
        {
            bool result = false;

            if (id.IsNullOrEmptyOrWhiteSpace())
                result = true;

            return result;
        }
    }
}
