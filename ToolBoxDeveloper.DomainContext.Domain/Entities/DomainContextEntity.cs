﻿using System;
using ToolBoxDeveloper.DomainContext.Domain.Entities.Base;
using ToolBoxDeveloper.DomainContext.Domain.Extensions;

namespace ToolBoxDeveloper.DomainContext.Domain.Entities
{
    public class DomainContextEntity : BaseEntity
    {
        public DomainContextEntity()
        {

        }
        public DomainContextEntity(string organization, string domain, string context, string key, string description, string userRegister)
        {
            if (string.IsNullOrWhiteSpace(organization))
                throw new ArgumentException("Organização é um campo obrigatorio");

            if (string.IsNullOrWhiteSpace(domain))
                throw new ArgumentException("Dominio é um campo obrigatorio");

            if (string.IsNullOrWhiteSpace(context))
                throw new ArgumentException("Contexto é um campo obrigatorio");

            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Chave é um campo obrigatorio");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Descrição é um campo obrigatorio");

            if (string.IsNullOrWhiteSpace(userRegister))
                throw new ArgumentException("Usuário que está registrando é um campo obrigatorio");


            this.Organization = organization;
            this.Domain = domain;
            this.Context = context;
            this.Key = key;
            this.Description = description;
            this.UserRegister = userRegister;
        }

        public string Organization { get; set; }
        public string Domain { get; set; }
        public string Context { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public string UserRegister { get; set; }
    }
}
