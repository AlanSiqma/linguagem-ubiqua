using AutoMapper;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Dto;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Entities;

namespace ToolBoxDeveloper.DomainContext.MVC.Mapper
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, UserDto>().ReverseMap();
        }
    }
}
