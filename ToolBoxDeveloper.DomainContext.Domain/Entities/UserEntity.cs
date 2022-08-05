using System;
using ToolBoxDeveloper.DomainContext.Domain.Entities.Base;
using ToolBoxDeveloper.DomainContext.Domain.Extensions;

namespace ToolBoxDeveloper.DomainContext.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public UserEntity(string email)
        {
            if (email.IsNullOrEmptyOrWhiteSpace())
                throw new ArgumentException("Email é um campo obrigatorio");

            this.Email = email;
        }
        internal UserEntity()
        {

        }
        public string Email { get; set; }

        public string Password
        {
            get; private set;
        }

        public void SetPassword(string password)
        {
            if (password.IsNullOrEmptyOrWhiteSpace())
                throw new ArgumentException("Senha é um campo obrigatorio");

            this.Password = password.Encrypt();
        }
    }
}
