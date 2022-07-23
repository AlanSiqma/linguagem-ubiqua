using AutoMapper;
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
        private readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public async Task AddOrUpdate(UserDto dto)
        {
            if (string.IsNullOrEmpty(dto.Id))
                await Create(dto);
            else
                await Update(dto);
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

        public async Task Delete(string id)
        {
            var entity = (await this._userRepository.Get(x => x.Id.Equals(id))).FirstOrDefault();

            await this._userRepository.Remove(entity);
        }

        public async Task<UserDto> Find(string id)
        {
            var entity = (await this._userRepository.Get(x => x.Id.Equals(id))).FirstOrDefault();

            return new UserDto(entity);
        }

        public async Task<List<UserDto>> GetAll()
        {
            var entities = await this._userRepository.Get();

            return entities.Select(x => new UserDto(x)).ToList();
        }

        public async Task<bool> Autenticate(UserDto dto)
        {
            bool result = false;

            var entity = await this._userRepository.Get(x => x.Email.Equals(dto.Email) && x.Password.Equals(dto.Password.Encrypt()));
            if (entity.Count > 0)
                result = true;

            return result;
        }
    }
}
