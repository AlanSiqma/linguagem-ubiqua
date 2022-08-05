using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ToolBoxDeveloper.DomainContext.Domain.Dto
{
    [ExcludeFromCodeCoverage]
    public class UserDto
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Favor informar um usuário")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Favor informar uma senha")]
        public string Password { get; set; }
    }
}
