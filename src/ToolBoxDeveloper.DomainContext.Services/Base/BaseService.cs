using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Notifications;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Repositories;
using ToolBoxDeveloper.DomainContext.Domain.Dto;
using ToolBoxDeveloper.DomainContext.Domain.Dto.Base;
using ToolBoxDeveloper.DomainContext.Domain.Entities.Base;

namespace ToolBoxDeveloper.DomainContext.Services.Base
{
    public class BaseService<TEntity, TDto> where TEntity : BaseEntity, new()
          where TDto : BaseDto
    {
        private IRepositoryBase<TEntity> _repository;
        private IMapper _mapper;
        private INotifier _notifier;
        public BaseService(IRepositoryBase<TEntity> repository,
         IMapper mapper,
         INotifier notifier)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._notifier = notifier;
        }
        ~BaseService()
        {
            this._repository = null;
            this._mapper = null;
            this._notifier = null;
        }

        public async Task<List<TDto>> GetAll()
        {
            return _mapper.Map<List<TDto>>(await this._repository.Get());
        }

        public async Task<TDto> Find(string id)
        {
            return _mapper.Map<TDto>(await this.FindEntityById(id));
        }

        public async Task Delete(string id)
        {
            await this._repository.Remove(await this.FindEntityById(id));
        }

        private async Task<TEntity> FindEntityById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                this.HandleErrorMessage("Campo id é obrigatorio");

            return await this._repository.Get(id);
        }

        private void HandleErrorMessage(string message)
        {
            this._notifier.Handle(new NotificationDto(message));
            throw new ArgumentException(message);
        }
    }
}