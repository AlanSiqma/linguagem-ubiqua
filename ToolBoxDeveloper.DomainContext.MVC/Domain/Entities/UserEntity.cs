using ToolBoxDeveloper.DomainContext.MVC.Domain.Entities.Base;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Extensions;

namespace ToolBoxDeveloper.DomainContext.MVC.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Email { get; set; }

        public string Password
        {
            get; private set;
        }

        internal void SetPassword(string password)
        {
            this.Password = password.Encrypt();
        }
    }
}
