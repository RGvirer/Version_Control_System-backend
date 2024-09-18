namespace DAL.Models;

public partial class Branch
{
    public int BranchId { get; set; }

    public int RepositoryId { get; set; }

    public string Name { get; set; } = null!;

    public bool IsMain { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Merge> MergeSourceBranches { get; set; } = new List<Merge>();

    public virtual ICollection<Merge> MergeTargetBranches { get; set; } = new List<Merge>();

    public virtual Repository Repository { get; set; } = null!;

    public virtual ICollection<Version> Versions { get; set; } = new List<Version>();
}
