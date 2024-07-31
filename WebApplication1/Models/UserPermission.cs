using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class UserPermission
{
    public int UserPermissionId { get; set; }

    public int UserId { get; set; }

    public int PermissionId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Permission Permission { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
