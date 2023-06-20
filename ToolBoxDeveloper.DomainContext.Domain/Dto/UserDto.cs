﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using ToolBoxDeveloper.DomainContext.Domain.Dto.Base;

namespace ToolBoxDeveloper.DomainContext.Domain.Dto
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
