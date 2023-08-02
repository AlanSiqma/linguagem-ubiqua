using Devtoolkit.LinguagemUbiqua.Domain.Dto.Base;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Devtoolkit.LinguagemUbiqua.Domain.Dto
{
    [ExcludeFromCodeCoverage]
    public class UserDto : BaseDto
    {

        [Required(ErrorMessage = "Favor informar um usuário")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Favor informar uma senha")]
        public string Password { get; set; }

    }
}
