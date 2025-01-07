using HospitalManagementApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementApp.Core.Entities;

public class Insurance : AuditableEntity
{
    public string PersonInsurance { get; set; }
    public float Discount { get; set; }
    public ICollection<Patient>? Patients { get; set; }
}
