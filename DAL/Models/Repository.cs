namespace DAL.Models;

public partial class Repository
{
    public int RepositoryId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string? Description { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public User User { get; set; } = null!;
}
