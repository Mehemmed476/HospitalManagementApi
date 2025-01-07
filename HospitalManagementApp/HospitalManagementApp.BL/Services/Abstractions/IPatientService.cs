using HospitalManagementApp.BL.DTOs.PatientDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementApp.BL.Services.Abstractions;

public interface IPatientService
{
    Task<ICollection<PatientGetDto>> GetAllAsync();
    Task<PatientGetDto> GetByIdAsync(int id);
    Task<bool> AddAsync(PatientPostDto patientPostDto);
    Task<bool> UpdateAsync(int id, PatientPutDto patientPutDto);
    Task<bool> SoftDeleteAsync(int id);
    Task<bool> RestoreAsync(int id);
    Task<bool> DeleteAsync(int id);
}
