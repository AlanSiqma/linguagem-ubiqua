using ToolBoxDeveloper.DomainContext.MVC.Domain.Dto;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Entities.Base;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Extensions;

namespace ToolBoxDeveloper.DomainContext.MVC.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        internal UserEntity BuildDto(UserDto dto)
        {
            this.Id = dto.Id;
            this.Email = dto.Email;
            this.Password = dto.Password.Encrypt();
            return this;
        }
        public override string ToString()
        {
            return "UserEntity";
        }
    }
}
