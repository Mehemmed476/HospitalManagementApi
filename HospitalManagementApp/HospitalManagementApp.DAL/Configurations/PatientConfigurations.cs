using HospitalManagementApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementApp.DAL.Configurations;

public class PatientConfigurations : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder
            .HasOne(p => p.Insurance)
            .WithMany(p => p.Patients)
            .HasForeignKey(p => p.InsuranceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
