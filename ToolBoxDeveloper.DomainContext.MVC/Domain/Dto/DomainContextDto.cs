using System;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Entities;

namespace ToolBoxDeveloper.DomainContext.MVC.Domain.Dto
{
    public class DomainContextDto
    {
        
        public DomainContextDto(DomainContextEntity entity)
        {
            this.Id = entity.Id;
            this.Organization = entity.Organization;
            this.Domain = entity.Domain;
            this.Context = entity.Context;
            this.Key = entity.Key;
            this.Description = entity.Description;
            this.UserRegister = entity.UserRegister;
        }
        public DomainContextDto()
        {

        }

        public string Id { get; set; }
        public string Organization { get; set; }
        public string Domain { get; set; }
        public string Context { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public string UserRegister { get; set; }

        internal DomainContextDto SetEmail(string userRegister)
        {
            this.UserRegister = userRegister;
            return this;
        }
    }
}
