namespace Contracts.Models;

public partial class WorkTypeCode
{
    public int Id { get; set; }

    public string? WorkTypeCode1 { get; set; }

    public string? WorkTypeDescription { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
