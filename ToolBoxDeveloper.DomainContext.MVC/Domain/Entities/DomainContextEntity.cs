using System;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Dto;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Entities.Base;

namespace ToolBoxDeveloper.DomainContext.MVC.Domain.Entities
{
    public class DomainContextEntity:BaseEntity
    {
        public string Organization { get; set; }
        public string Domain { get; set; }
        public string Context { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public string UserRegister { get; set; }

        internal DomainContextEntity BuildDto(DomainContextDto dto)
        {
            this.Id = dto.Id;
            this.Organization = dto.Organization;
            this.Domain = dto.Domain;
            this.Context = dto.Context;
            this.Key = dto.Key;
            this.Description = dto.Description;
            this.UserRegister = dto.UserRegister;

            return this;
        }
        public override string ToString()
        {
            return "DomainContextEntity";
        }
    }
}
