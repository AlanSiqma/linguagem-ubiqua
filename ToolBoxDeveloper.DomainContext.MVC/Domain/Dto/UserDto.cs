using System.ComponentModel.DataAnnotations;

namespace ToolBoxDeveloper.DomainContext.MVC.Domain.Dto
{
    public class UserDto
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Favor informar um usuário")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Favor informar uma senha")]
        public string Password { get; set; }
    }
}
