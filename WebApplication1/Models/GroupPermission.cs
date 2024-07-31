using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class GroupPermission
{
    public int GroupPermissionId { get; set; }

    public int GroupId { get; set; }

    public int PermissionId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual UserGroup Group { get; set; } = null!;

    public virtual Permission Permission { get; set; } = null!;
}
