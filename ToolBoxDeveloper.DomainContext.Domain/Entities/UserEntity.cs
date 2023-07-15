﻿using System;
using ToolBoxDeveloper.DomainContext.Domain.Entities.Base;
using ToolBoxDeveloper.DomainContext.Domain.Extensions;

namespace ToolBoxDeveloper.DomainContext.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public UserEntity(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email é um campo obrigatorio");

            this.Email = email;
        }
        public UserEntity()
        {

        }
        public string Email { get; set; } = string.Empty;

        public string Password { get; private set; } = string.Empty; 

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Senha é um campo obrigatorio");

            this.Password = password.Encrypt();
        }
    }
}
