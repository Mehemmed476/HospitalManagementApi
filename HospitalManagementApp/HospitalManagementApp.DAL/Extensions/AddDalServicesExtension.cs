using HospitalManagementApp.DAL.Contexts;
using HospitalManagementApp.DAL.Helpers;
using HospitalManagementApp.DAL.Repositories.Abstractions;
using HospitalManagementApp.DAL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementApp.DAL.Extensions;

public static class AddDalServicesExtension
{
    
    public static void AddDalServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(
            opt =>
            {
                opt.UseSqlServer(ConnectionStr.GetConnectionString());
            });

        services.AddScoped<IInsuranceRepository, InsuranceRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
    }
}
