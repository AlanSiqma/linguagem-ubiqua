using AutoMapper;
using Devtoolkit.LinguagemUbiqua.Domain.Dto;
using Devtoolkit.LinguagemUbiqua.Domain.Entities;

namespace Devtoolkit.LinguagemUbiqua.MVC.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, UserDto>().ReverseMap();
        }
    }
}