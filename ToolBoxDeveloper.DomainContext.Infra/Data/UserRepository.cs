﻿using ToolBoxDeveloper.DomainContext.Domain.Contracts.Repositories;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Settings;
using ToolBoxDeveloper.DomainContext.Domain.Entities;
using ToolBoxDeveloper.DomainContext.Infra.Data.Base;

namespace ToolBoxDeveloper.DomainContext.Infra.Data
{
    public class UserRepository: RepositoryBase<UserEntity>, IUserRepository
    {
        public UserRepository(IDatabaseSettings settings):base(settings)
        {

        }
    }
}
