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

namespace ToolBoxDeveloper.DomainContext.Services
{
    public class UserService : IUserService
    {
       
        private readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;
        private readonly INotifier _notifier;
        public UserService(IUserRepository userRepository, IMapper mapper, INotifier notifier)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;          
            this._notifier = notifier;
        }

        public async Task AddOrUpdate(UserDto dto)
        {
            if (dto.Id.IsNullOrEmptyOrWhiteSpace())
                await this.Create(dto);
            else
                await this.Update(dto);
        }

        public async Task Delete(string id)
        {
            await this._userRepository.Remove(await this.FindEntityById(id));
        }

        public async Task<UserDto> Find(string id)
        {
            return _mapper.Map<UserDto>(await this.FindEntityById(id));
        }

        public async Task<List<UserDto>> GetAll()
        {
            return _mapper.Map<List<UserDto>>(await this._userRepository.Get());
        }

        public async Task<bool> Autenticate(UserDto dto)
        {
            bool result = false;

            var entity = await this._userRepository.Get(x => x.Email.Equals(dto.Email) && x.Password.Equals(dto.Password.Encrypt()));
            
            if (entity.Count > 0)
                result = true;

            return result;
        }

        private async Task<UserEntity> FindEntityById(string id)
        {
            if (id.IsNullOrEmptyOrWhiteSpace())
            {
                this._notifier.Handle(new NotificationDto("Campo id é obrigatorio"));
                throw new ArgumentException("Campo id é obrigatorio");
            }

            return (await this._userRepository.Get(x => x.Id.Equals(id))).FirstOrDefault();
        }

        private async Task Update(UserDto dto)
        {
            UserEntity entity = _mapper.Map<UserEntity>(dto);

            entity.SetPassword(dto.Password);

            await this._userRepository.Update(dto.Id, entity);
        }

        private async Task Create(UserDto dto)
        {
            if (await this.EmailExists(dto))
                return;
           
            UserEntity entityMap = _mapper.Map<UserEntity>(dto);
            
            entityMap.SetPassword(dto.Password);

            await this._userRepository.Create(entityMap);
        }
        private async Task<bool> EmailExists(UserDto dto)
        {
            bool result = false;

            var entities = await this._userRepository.Get(x => x.Email.Equals(dto.Email));

            if (entities.Count > 0)
            {
                this._notifier.Handle(new NotificationDto($"E-mail: {dto.Email}, já está cadastrado",true));
                result = true;
            }

            return result;
        }
    }
}
