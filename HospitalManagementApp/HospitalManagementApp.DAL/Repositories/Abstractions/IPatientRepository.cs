using HospitalManagementApp.Core.Entities;
using HospitalManagementApp.DAL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementApp.DAL.Repositories.Abstractions;

public interface IPatientRepository : IRepository<Patient> { }
