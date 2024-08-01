using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string? PatientName { get; set; }

    public int? PatientAge { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}
