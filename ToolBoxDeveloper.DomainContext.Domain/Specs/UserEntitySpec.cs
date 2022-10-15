using System;
using System.Linq.Expressions;
using ToolBoxDeveloper.DomainContext.Domain.Dto;
using ToolBoxDeveloper.DomainContext.Domain.Entities;
using ToolBoxDeveloper.DomainContext.Domain.Extensions;

namespace ToolBoxDeveloper.DomainContext.Domain.Specs
{
    public static  class UserEntitySpec
    {
        public static Expression<Func<UserEntity,bool>> Autenticate(UserDto dto)
        {
            return x => x.Email.Equals(dto.Email) && x.Password.Equals(dto.Password.Encrypt());
        }

        public static Expression<Func<UserEntity, bool>> FindEntityByEmail(string email)
        {
            return x => x.Email.Equals(email);
        }
    }
}
