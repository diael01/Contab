using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public partial class Organisation
{
    public HierarchyId OrgNode { get; set; } = null!;

    public string? OrgNodeText { get; set; }

    public HierarchyId? ParentNode { get; set; }

    public string? ParentNodeText { get; set; }

    public short? OrgLevel { get; set; }

    public string Name { get; set; } = null!;

    public string? LongName { get; set; }

    public string? CountyCode { get; set; }

    public string? Location { get; set; }

    public int? CodCor { get; set; }

    public string? CodGrm { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
