﻿using AutoMapper;
using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Notifications;
using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Repositories;
using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Services;
using Devtoolkit.LinguagemUbiqua.Domain.Dto;
using Devtoolkit.LinguagemUbiqua.Domain.Entities;
using Devtoolkit.LinguagemUbiqua.Services.Base;
using System.Threading.Tasks;

namespace Devtoolkit.LinguagemUbiqua.Services
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
            if (string.IsNullOrWhiteSpace(dto.Id))
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