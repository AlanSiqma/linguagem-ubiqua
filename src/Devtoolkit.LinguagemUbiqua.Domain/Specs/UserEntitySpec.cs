using Devtoolkit.LinguagemUbiqua.Domain.Dto;
using Devtoolkit.LinguagemUbiqua.Domain.Entities;
using Devtoolkit.LinguagemUbiqua.Domain.Extensions;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace Devtoolkit.LinguagemUbiqua.Domain.Specs
{
    [ExcludeFromCodeCoverage]
    public static class UserEntitySpec
    {
        public static Expression<Func<UserEntity, bool>> Autenticate(UserDto dto)
        {
            return x => x.Email.Equals(dto.Email) && x.Password.Equals(dto.Password.Encrypt());
        }

        public static Expression<Func<UserEntity, bool>> FindEntityByEmail(string email)
        {
            return x => x.Email.Equals(email);
        }
    }
}
