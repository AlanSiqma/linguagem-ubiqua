using AutoMapper;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Dto;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Entities;

namespace ToolBoxDeveloper.DomainContext.MVC.Mapper
{
    public class DomainContextProfile:Profile
    {
        public DomainContextProfile()
        {
            CreateMap<DomainContextEntity, DomainContextDto>().ReverseMap();
        }
    }
}
