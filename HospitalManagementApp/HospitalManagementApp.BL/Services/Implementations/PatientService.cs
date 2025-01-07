using AutoMapper;
using HospitalManagementApp.BL.DTOs.PatientDTOs;
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

public class PatientService : IPatientService
{ 
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;

    public PatientService(IPatientRepository patientRepository, IMapper mapper)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<PatientGetDto>> GetAllAsync()
    {
        ICollection<Patient> categories = await _patientRepository.GetAllAsync()
                                           ?? throw new EntityNotFoundException("Patient not found");

        return _mapper.Map<ICollection<PatientGetDto>>(categories);
    }

    public async Task<PatientGetDto> GetByIdAsync(int id)
    {
        Patient patient = await _patientRepository.GetByIdAsync(id)
                            ?? throw new EntityNotFoundException("Patient not found");

        return _mapper.Map<PatientGetDto>(patient);
    }

    public async Task<bool> AddAsync(PatientPostDto patientPostDto)
    {
        Patient patient = _mapper.Map<Patient>(patientPostDto);
        patient.CreatedAt = DateTime.UtcNow.AddHours(4);

        await _patientRepository.AddAsync(patient);
        await _patientRepository.SaveAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(int id, PatientPutDto patientPutDto)
    {
        var existingPatient = await _patientRepository.GetByIdAsync(id)
                                 ?? throw new EntityNotFoundException("Patient not found");

        _mapper.Map(patientPutDto, existingPatient);
        existingPatient.UpdatedAt = DateTime.UtcNow.AddHours(4);

        await _patientRepository.UpdateAsync(existingPatient);
        await _patientRepository.SaveAsync();

        return true;
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        Patient patient = await _patientRepository.GetByIdAsync(id)
                 ?? throw new EntityNotFoundException("Patient not found");

        if (patient.DeletedAt != null)
            throw new InvalidOperationException("Patient is already soft deleted");

        patient.DeletedAt = DateTime.UtcNow.AddHours(4);
        _patientRepository.SoftDelete(patient);
        await _patientRepository.SaveAsync();

        return true;
    }

    public async Task<bool> RestoreAsync(int id)
    {
        Patient patient = await _patientRepository.GetByIdAsync(id)
                             ?? throw new EntityNotFoundException("Patient not found");

        if (patient.DeletedAt == null)
            throw new InvalidOperationException("Patient is not soft deleted");

        patient.DeletedAt = null;
        _patientRepository.Restore(patient);
        await _patientRepository.SaveAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        Patient patient = await _patientRepository.GetByIdAsync(id)
                            ?? throw new EntityNotFoundException("Patient not found");

        _patientRepository.HardDelete(patient);
        await _patientRepository.SaveAsync();

        return true;
    }
}
