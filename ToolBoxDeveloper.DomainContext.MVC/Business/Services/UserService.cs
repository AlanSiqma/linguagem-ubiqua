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
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task AddOrUpdate(UserDto dto)
        {
            if (string.IsNullOrEmpty(dto.Id))
                await Create(dto);
            else
                await Update(dto);
        }
        private async Task<bool> Update(UserDto dto)
        {
            var result = true;
            try
            {
                await this._userRepository.Update(dto.Id, new UserEntity().BuildDto(dto));
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        private async Task<bool> Create(UserDto dto)
        {
            var result = true;
            try
            {
                await this._userRepository.Create(new UserEntity().BuildDto(dto));
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public async Task<bool> Delete(string id)
        {
            var result = false;
            try
            {
                var entity = (await this._userRepository.Get(x => x.Id.Equals(id))).FirstOrDefault();

                await this._userRepository.Remove(entity);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public async Task<UserDto> Find(string id)
        {
            UserDto result;
            try
            {
                var entity = (await this._userRepository.Get(x => x.Id.Equals(id))).FirstOrDefault();

                result = new UserDto(entity);

            }
            catch (Exception)
            {
                result = new UserDto();
            }

            return result;
        }

        public async Task<List<UserDto>> GetAll()
        {
            List<UserDto> result;
            try
            {
                var entities = await this._userRepository.Get();
                result = entities.Select(x => new UserDto(x)).ToList();
            }
            catch (Exception)
            {
                result = new List<UserDto>();
            }

            return result;
        }

        public async Task<bool> Autenticate(UserDto dto)
        {
            bool result = false;
            try
            {
                var entity = await this._userRepository.Get(x => x.Email.Equals(dto.Email) && x.Password.Equals(dto.Password.Encrypt()));
                if (entity.Count >0)
                    result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}
