using HospitalManagementApp.BL.Profiles.InsuranceProfiles;
using HospitalManagementApp.DAL.Contexts;
using HospitalManagementApp.DAL.Repositories.Abstractions;
using HospitalManagementApp.DAL.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using HospitalManagementApp.BL.Services.Abstractions;
using HospitalManagementApp.BL.Services.Implementations;


namespace HospitalManagementApp.BL.Extensions;

public static class AddBlServicesExtension
{
    public static void AddBlServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(InsuranceProfile));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();



        services.AddScoped<IInsuranceService, InsuranceService>();
        services.AddScoped<IPatientService, PatientService>();
    }
}
