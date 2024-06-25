using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public partial class Organisation
{
    public int Id { get; set; }

    public HierarchyId OrgNode { get; set; } = null!;

    public short? OrgLevel { get; set; }

    public int Type { get; set; }

    public string Name { get; set; } = null!;

    public string? LongName { get; set; }

    public string? Location { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
