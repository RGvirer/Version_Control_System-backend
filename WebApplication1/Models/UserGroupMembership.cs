using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class UserGroupMembership
{
    public int MembershipId { get; set; }

    public int UserId { get; set; }

    public int GroupId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual UserGroup Group { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
