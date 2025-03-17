using System;
using System.Collections.Generic;

namespace Contracts.Models;

public partial class RoleClaim
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public int ClaimId { get; set; }
}
