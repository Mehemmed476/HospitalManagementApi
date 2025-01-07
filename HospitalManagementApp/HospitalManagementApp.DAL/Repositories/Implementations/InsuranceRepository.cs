using HospitalManagementApp.Core.Entities;
using HospitalManagementApp.DAL.Contexts;
using HospitalManagementApp.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementApp.DAL.Repositories.Implementations;

public class InsuranceRepository : Repository<Insurance>, IInsuranceRepository
{
    public InsuranceRepository(AppDbContext context) : base(context)
    {
    }

    
}
