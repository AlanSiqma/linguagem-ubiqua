﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ToolBoxDeveloper.DomainContext.Domain.Dto.Base;
using ToolBoxDeveloper.DomainContext.Domain.Extensions;

namespace ToolBoxDeveloper.DomainContext.Domain.Dto
{
    public class DomainContextDto : BaseDto
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
        [DisplayName("Empresa")]
        [Required(ErrorMessage = "Favor informar uma Empresa")]
        public string Organization { get; set; }

        [DisplayName("Dominio")]
        [Required(ErrorMessage = "Favor informar um Dominio")]
        public string Domain { get; set; }

        [DisplayName("Contexto")]
        [Required(ErrorMessage = "Favor informar um Contexto")]
        public string Context { get; set; }

        [DisplayName("Chave")]
        [Required(ErrorMessage = "Favor informar uma Chave")]
        public string Key { get; set; }

        [DisplayName("Valor")]
        [Required(ErrorMessage = "Favor informar um Valor")]
        public string Description { get; set; }
        public string UserRegister { get; set; }

        public DomainContextDto SetEmail(string userRegister)
        {
            if (string.IsNullOrWhiteSpace(userRegister))
                throw new ArgumentException("Email é um campo obrigatorio");

            this.UserRegister = userRegister;
            return this;
        }
    }
}
