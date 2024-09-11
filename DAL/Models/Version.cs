using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Version
{
    public int Id { get; set; }

    public int BranchId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int AuthorId { get; set; }

    public string? Description { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual Branch Branch { get; set; } = null!;
}
