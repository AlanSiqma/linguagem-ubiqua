using Microsoft.Extensions.Logging;
using System;
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
        public DomainContextService(IDomainContextRepository domainContextRepository, ILogger<DomainContextService> logger)
        {
            this._domainContextRepository = domainContextRepository;
            this._logger = logger;
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
            await this._domainContextRepository.Update(dto.Id, new DomainContextEntity().BuildDto(dto));
        }

        private async Task Create(DomainContextDto dto)
        {
            await this._domainContextRepository.Create(new DomainContextEntity().BuildDto(dto));
        }

        public async Task Delete(string id)
        {
            var entity = (await this._domainContextRepository.Get(x => x.Id.Equals(id))).FirstOrDefault();

            await this._domainContextRepository.Remove(entity);
        }

        public async Task<DomainContextDto> Find(string id)
        {
            var entity = (await this._domainContextRepository.Get(x => x.Id.Equals(id))).FirstOrDefault();

            return new DomainContextDto(entity);
        }

        public async Task<List<DomainContextDto>> GetAll()
        {
            var entities = await this._domainContextRepository.Get();

            return entities.Select(x => new DomainContextDto(x)).ToList();
        }
    }
}
