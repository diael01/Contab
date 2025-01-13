using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Contracts.Models;

public partial class Organisation
{
    public HierarchyId Node { get; set; } = null!;

    public string? NodeText { get; set; }

    public string? NodeName { get; set; }

    public HierarchyId? ParentNode { get; set; }

    public short? NodeLevel { get; set; }

    public string Name { get; set; } = null!;

    public string? CountyCode { get; set; }

    public string? Location { get; set; }

    public int? CodCor { get; set; }

    public string? CodGrm { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
