using AutoMapper;
using HospitalManagementApp.BL.DTOs.InsuranceDTOs;
using HospitalManagementApp.BL.Services.Abstractions;
using HospitalManagementApp.Core.Entities;
using HospitalManagementApp.DAL.Exceptions;
using HospitalManagementApp.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementApp.BL.Services.Implementations;

public class InsuranceService : IInsuranceService
{
    private readonly IInsuranceRepository _insuranceRepository;
    private readonly IMapper _mapper;

    public InsuranceService(IInsuranceRepository insuranceRepository, IMapper mapper)
    {
        _insuranceRepository = insuranceRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<InsuranceGetDto>> GetAllAsync()
    {
        ICollection<Insurance> categories = await _insuranceRepository.GetAllAsync()
                                           ?? throw new EntityNotFoundException("Insurance not found");

        return _mapper.Map<ICollection<InsuranceGetDto>>(categories);
    }

    public async Task<InsuranceGetDto> GetByIdAsync(int id)
    {
        Insurance insurance = await _insuranceRepository.GetByIdAsync(id)
                            ?? throw new EntityNotFoundException("Insurance not found");

        return _mapper.Map<InsuranceGetDto>(insurance);
    }

    public async Task<bool> AddAsync(InsurancePostDto insurancePostDto)
    {
        Insurance insurance = _mapper.Map<Insurance>(insurancePostDto);
        insurance.CreatedAt = DateTime.UtcNow.AddHours(4);

        await _insuranceRepository.AddAsync(insurance);
        await _insuranceRepository.SaveAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(int id, InsurancePutDto insurancePutDto)
    {
        var existingInsurance = await _insuranceRepository.GetByIdAsync(id)
                                 ?? throw new EntityNotFoundException("Insurance not found");

        _mapper.Map(insurancePutDto, existingInsurance);
        existingInsurance.UpdatedAt = DateTime.UtcNow.AddHours(4);

        await _insuranceRepository.UpdateAsync(existingInsurance);
        await _insuranceRepository.SaveAsync();

        return true;
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        Insurance insurance = await _insuranceRepository.GetByIdAsync(id)
                 ?? throw new EntityNotFoundException("Insurance not found");

        if (insurance.DeletedAt != null)
            throw new InvalidOperationException("Insurance is already soft deleted");

        insurance.DeletedAt = DateTime.UtcNow.AddHours(4);
        _insuranceRepository.SoftDelete(insurance);
        await _insuranceRepository.SaveAsync();

        return true;
    }

    public async Task<bool> RestoreAsync(int id)
    {
        Insurance insurance = await _insuranceRepository.GetByIdAsync(id)
                             ?? throw new EntityNotFoundException("Insurance not found");

        if (insurance.DeletedAt == null)
            throw new InvalidOperationException("Insurance is not soft deleted");

        insurance.DeletedAt = null;
        _insuranceRepository.Restore(insurance);
        await _insuranceRepository.SaveAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        Insurance insurance = await _insuranceRepository.GetByIdAsync(id)
                            ?? throw new EntityNotFoundException("Insurance not found");

        _insuranceRepository.HardDelete(insurance);
        await _insuranceRepository.SaveAsync();

        return true;
    }
}
