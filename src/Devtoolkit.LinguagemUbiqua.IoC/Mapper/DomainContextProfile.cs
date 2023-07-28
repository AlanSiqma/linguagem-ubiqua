using AutoMapper;
using Devtoolkit.LinguagemUbiqua.Domain.Dto;
using Devtoolkit.LinguagemUbiqua.Domain.Entities;

namespace Devtoolkit.LinguagemUbiqua.MVC.Mapper
{
    public class DomainContextProfile : Profile
    {
        public DomainContextProfile()
        {
            CreateMap<DomainContextEntity, DomainContextDto>().ReverseMap();
        }
    }
}