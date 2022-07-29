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
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
            this._logger = logger;
        }

        public async Task AddOrUpdate(UserDto dto)
        {
            if (string.IsNullOrEmpty(dto.Id))
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
                throw new ArgumentException("Campo id é obrigatorio");

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
            UserEntity entity = _mapper.Map<UserEntity>(dto);

            entity.SetPassword(dto.Password);

            await this._userRepository.Create(entity);
        }
    }
}
