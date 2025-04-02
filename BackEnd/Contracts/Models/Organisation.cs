using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Contracts.Models;

public partial class Organisation
{
        public int Id { get; set; }

    public HierarchyId? Node { get; set; }

    public string NodeName { get; set; } = null!;

    public HierarchyId? ParentNode { get; set; }

    public string? ParentNodeName { get; set; }

    public short? NodeLevel { get; set; }

    public string? CountyCode { get; set; }

    public string? Location { get; set; }

    public int? CodCor { get; set; }

    public string? CodGrm { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
