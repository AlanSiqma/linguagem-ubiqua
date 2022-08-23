﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.Domain.Dto;

namespace ToolBoxDeveloper.DomainContext.Domain.Contracts.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAll();
        Task AddOrUpdate(UserDto dto);
        Task<UserDto> Find(string id);
        Task Delete(string id);
        Task<bool> Autenticate(UserDto dto);
    }
}
