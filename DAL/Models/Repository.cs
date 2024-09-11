﻿using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Repository
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string? Description { get; set; }

    public int OwnerId { get; set; }

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual User Owner { get; set; } = null!;
}
