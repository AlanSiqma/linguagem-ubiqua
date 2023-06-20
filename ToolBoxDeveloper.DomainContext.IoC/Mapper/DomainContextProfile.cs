using AutoMapper;
using ToolBoxDeveloper.DomainContext.Domain.Dto;
using ToolBoxDeveloper.DomainContext.Domain.Entities;

namespace ToolBoxDeveloper.DomainContext.MVC.Mapper
{
    public class DomainContextProfile : Profile
    {
        public DomainContextProfile()
        {
            CreateMap<DomainContextEntity, DomainContextDto>().ReverseMap();
        }
    }
}
