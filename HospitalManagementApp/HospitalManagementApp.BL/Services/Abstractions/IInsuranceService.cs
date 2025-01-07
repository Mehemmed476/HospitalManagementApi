using HospitalManagementApp.BL.DTOs.InsuranceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementApp.BL.Services.Abstractions;

public interface IInsuranceService
{
    Task<ICollection<InsuranceGetDto>> GetAllAsync();
    Task<InsuranceGetDto> GetByIdAsync(int id);
    Task<bool> AddAsync(InsurancePostDto insurancePostDto);
    Task<bool> UpdateAsync(int id, InsurancePutDto insurancePutDto);
    Task<bool> SoftDeleteAsync(int id);
    Task<bool> RestoreAsync(int id);
    Task<bool> DeleteAsync(int id);
}
