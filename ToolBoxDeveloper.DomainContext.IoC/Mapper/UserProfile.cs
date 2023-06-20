using AutoMapper;
using ToolBoxDeveloper.DomainContext.Domain.Dto;
using ToolBoxDeveloper.DomainContext.Domain.Entities;

namespace ToolBoxDeveloper.DomainContext.MVC.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, UserDto>().ReverseMap();
        }
    }
}
