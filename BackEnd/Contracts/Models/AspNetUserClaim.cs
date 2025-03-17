using System;
using System.Collections.Generic;

namespace Contracts.Models;

public partial class AspNetUserClaim
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ClaimId { get; set; }
}
