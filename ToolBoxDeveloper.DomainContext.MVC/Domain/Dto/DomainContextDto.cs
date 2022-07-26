using System;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Extensions;

namespace ToolBoxDeveloper.DomainContext.MVC.Domain.Dto
{
    public class DomainContextDto
    {
        public string Id { get; set; }
        public string Organization { get; set; }
        public string Domain { get; set; }
        public string Context { get; set; }
        public string Key { get; set; }
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
