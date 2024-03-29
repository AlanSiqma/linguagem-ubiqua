﻿using AutoMapper;
using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Notifications;
using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Repositories;
using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Services;
using Devtoolkit.LinguagemUbiqua.Domain.Dto;
using Devtoolkit.LinguagemUbiqua.Domain.Entities;
using Devtoolkit.LinguagemUbiqua.Domain.Specs;
using Devtoolkit.LinguagemUbiqua.Services.Base;
using System.Threading.Tasks;

namespace Devtoolkit.LinguagemUbiqua.Services
{
    public class UserService : BaseService<UserEntity, UserDto>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly INotifier _notifier;
        public UserService(IUserRepository repository, IMapper mapper, INotifier notifier) : base(repository, mapper, notifier)
        {
            this._userRepository = repository;
            this._mapper = mapper;
            this._notifier = notifier;
        }

        public async Task AddOrUpdate(UserDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Id))
                await this.Create(dto);
            else
                await this.Update(dto);
        }

        public async Task<bool> Autenticate(UserDto dto)
        {
            var entity = await this._userRepository.Get(UserEntitySpec.Autenticate(dto));

            if (entity.Count > 0)
                return true;

            return false;
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
            var entities = await this._userRepository.Get(UserEntitySpec.FindEntityByEmail(dto.Email));

            if (entities == null || entities.Count > 0)
            {
                this._notifier.Handle(new NotificationDto($"E-mail: {dto.Email}, já está cadastrado", true));
                return true;
            }

            return false;
        }
    }
}