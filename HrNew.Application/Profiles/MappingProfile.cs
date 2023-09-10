using AutoMapper;
using HrNew.Application.DTOs.HrAllocation;
using HrNew.Application.DTOs.HrRequest;
using HrNew.Application.DTOs.HrType;
using HrNew.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HrRequest, HrRequestDto>().ReverseMap();
            CreateMap<HrAllocation, HrAllocationDto>().ReverseMap();
            CreateMap<HrType, HrTypeDto>().ReverseMap();

            CreateMap<HrRequest, HrRequestListDto>().ReverseMap();

            CreateMap<HrRequest, CreateHrRequestDto>().ReverseMap();
            CreateMap<HrAllocation, CreateHrAllocationDto>().ReverseMap();
            CreateMap<HrType, CreateHrTypeDto>().ReverseMap();


        }
    }
}
