using AutoMapper;
using HospitalManagementApp.BL.DTOs.InsuranceDTOs;
using HospitalManagementApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementApp.BL.Profiles.InsuranceProfiles;

public class InsuranceProfile : Profile
{
    public InsuranceProfile()
    {
        CreateMap<InsuranceGetDto, Insurance>().ReverseMap();
        CreateMap<InsurancePostDto, Insurance>().ReverseMap();
        CreateMap<InsuranceGetDto, Insurance>().ReverseMap();
    }
}
