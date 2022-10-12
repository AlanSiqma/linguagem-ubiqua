﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Notifications;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Repositories;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Services;
using ToolBoxDeveloper.DomainContext.Domain.Dto;
using ToolBoxDeveloper.DomainContext.Domain.Entities;
using ToolBoxDeveloper.DomainContext.Domain.Extensions;
using ToolBoxDeveloper.DomainContext.Domain.Specs;

namespace ToolBoxDeveloper.DomainContext.Services
{
    public class DomainContextService : IDomainContextService
    {
       
        private readonly IDomainContextRepository _domainContextRepository;
        public readonly IMapper _mapper;
        private readonly INotifier _notifier;
        public DomainContextService(IDomainContextRepository domainContextRepository,            
            IMapper mapper,
            INotifier notifier)
        {
            this._domainContextRepository = domainContextRepository;
         
            this._mapper = mapper;
            this._notifier = notifier;
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
                this.HandleErrorMessage("Campo id é obrigatorio");
            
            var result = await this._domainContextRepository.Get(DomainContextEntitySpec.FindEntityById(id));

            return result.FirstOrDefault();
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
        private void HandleErrorMessage(string message)
        {
            this._notifier.Handle(new NotificationDto(message));
            throw new ArgumentException(message);
        }
    }
}
