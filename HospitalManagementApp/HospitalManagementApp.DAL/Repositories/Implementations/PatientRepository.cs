using HospitalManagementApp.Core.Entities;
using HospitalManagementApp.DAL.Contexts;
using HospitalManagementApp.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementApp.DAL.Repositories.Implementations;

public class PatientRepository : Repository<Patient>, IPatientRepository
{
    public PatientRepository(AppDbContext context) : base(context)
    {
    }
}
