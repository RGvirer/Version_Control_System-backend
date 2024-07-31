﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
