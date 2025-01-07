using AutoMapper;
using HospitalManagementApp.BL.DTOs.PatientDTOs;
using HospitalManagementApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementApp.BL.Profiles.PatientProfiles;

public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<PatientGetDto, Patient>().ReverseMap();
        CreateMap<PatientPostDto, Patient>().ReverseMap();
        CreateMap<PatientPutDto, Patient>().ReverseMap();
    }
}
