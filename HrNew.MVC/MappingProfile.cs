using AutoMapper;
using HrNew.MVC.Models;
using HrNew.MVC.Services.Base;

namespace HrNew.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateHrAllocationDto, CreateHrAllocationVM>().ReverseMap();
            CreateMap<CreateHrTypeDto, CreateHrTypeVM>().ReverseMap();
            CreateMap<CreateHrRequestDto, CreateHrRequestVM>().ReverseMap();
            CreateMap<HrTypeDto, HrTypeVM>().ReverseMap();
            CreateMap<HrAllocationDto, HrAllocationVM>().ReverseMap();
            CreateMap<HrRequestDto, HrRequestVM>().ForMember(q => q.StartDate, opt => opt.MapFrom(x => x.StartDate.DateTime))
                .ForMember(q => q.EndDate, opt => opt.MapFrom(x => x.EndDate.DateTime))
                .ReverseMap();
            CreateMap<RegisterVM, RegistrationRequest>().ReverseMap();
            CreateMap<UpdateHrRequestDto, HrRequestVM>().ReverseMap();
        }
    }
}
