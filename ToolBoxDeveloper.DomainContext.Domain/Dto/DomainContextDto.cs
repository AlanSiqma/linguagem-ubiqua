using System;
using System.ComponentModel;
using ToolBoxDeveloper.DomainContext.Domain.Extensions;

namespace ToolBoxDeveloper.DomainContext.Domain.Dto
{
    public class DomainContextDto
    {
        public DomainContextDto()
        {

        }
        public DomainContextDto(string organization, string domain, string context, string key, string description, string userRegister)
        {
            this.Organization = organization;
            this.Domain = domain;
            this.Context = context;
            this.Key = key;
            this.Description = description;
            this.UserRegister = userRegister;
        }
        public string Id { get; set; }

        [DisplayName("Empresa")]
        public string Organization { get; set; }

        [DisplayName("Dominio")]
        public string Domain { get; set; }

        [DisplayName("Contexto")]
        public string Context { get; set; }

        [DisplayName("Chave")]
        public string Key { get; set; }

        [DisplayName("Valor")]
        public string Description { get; set; }
        public string UserRegister { get; set; }

        public DomainContextDto SetEmail(string userRegister)
        {
            if (userRegister.IsNullOrEmptyOrWhiteSpace())
                throw new ArgumentException("Email é um campo obrigatorio");

            this.UserRegister = userRegister;
            return this;
        }
    }
}
