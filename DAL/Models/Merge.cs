using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Merge
{
    public int Id { get; set; }

    public int SourceBranchId { get; set; }

    public int TargetBranchId { get; set; }

    public DateTime MergedAt { get; set; }

    public virtual Branch SourceBranch { get; set; } = null!;

    public virtual Branch TargetBranch { get; set; } = null!;
}
