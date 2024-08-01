using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class UserGroup
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<GroupPermission> GroupPermissions { get; set; } = new List<GroupPermission>();

    public virtual ICollection<UserGroupMembership> UserGroupMemberships { get; set; } = new List<UserGroupMembership>();
}
