using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementApp.BL.DTOs.InsuranceDTOs;

public class InsurancePutDto
{
    public string PersonInsurance { get; set; }
    public float Discount { get; set; }
}