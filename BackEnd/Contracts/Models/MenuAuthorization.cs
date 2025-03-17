using System;
using System.Collections.Generic;

namespace Contracts.Models;

public partial class MenuAuthorization
{
    public int Id { get; set; }

    public int MenuId { get; set; }

    public int RoleId { get; set; }
}
