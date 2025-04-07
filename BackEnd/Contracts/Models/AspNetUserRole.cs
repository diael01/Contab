using System;
using System.Collections.Generic;

namespace Contracts.Models;

public partial class AspNetUserRole
{
    public int UserId { get; set; }

    public int RoleId { get; set; }
}
