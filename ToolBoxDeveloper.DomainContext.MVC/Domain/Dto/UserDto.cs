using System;
using System.ComponentModel.DataAnnotations;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Entities;

namespace ToolBoxDeveloper.DomainContext.MVC.Domain.Dto
{
    public class UserDto
    {

        public UserDto()
        {
        }

        public UserDto(UserEntity entity)
        {
            this.Id = entity.Id;
            this.Email = entity.Email;
            this.Password = entity.Password;
        }

        public string Id { get; set; }
        [Required(ErrorMessage = "Favor informar um usuário")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Favor informar uma senha")]
        public string Password { get; set; }

    }
}
