using HospitalManagementApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementApp.BL.DTOs.InsuranceDTOs;

public class InsuranceGetDto
{
    public string PersonInsurance { get; set; }
    public float Discount { get; set; }
    public ICollection<Patient>? Patients { get; set; }
}