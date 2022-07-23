using System;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Dto;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Entities.Base;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Extensions;

namespace ToolBoxDeveloper.DomainContext.MVC.Domain.Entities
{
    public class DomainContextEntity : BaseEntity
    {
        internal DomainContextEntity()
        {

        }
        public DomainContextEntity(string organization, string domain, string context, string key, string description, string userRegister)
        {
            if (organization.IsNullOrEmptyOrWhiteSpace())
                throw new ArgumentNullException("Organização é um campo obrigatorio");

            if (domain.IsNullOrEmptyOrWhiteSpace())
                throw new ArgumentNullException("Dominio é um campo obrigatorio");

            if (context.IsNullOrEmptyOrWhiteSpace())
                throw new ArgumentNullException("Contexto é um campo obrigatorio");

            if (key.IsNullOrEmptyOrWhiteSpace())
                throw new ArgumentNullException("Chave é um campo obrigatorio");

            if (description.IsNullOrEmptyOrWhiteSpace())
                throw new ArgumentNullException("Descrição é um campo obrigatorio");

            if (userRegister.IsNullOrEmptyOrWhiteSpace())
                throw new ArgumentNullException("Usuário que está registrando é um campo obrigatorio");


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
