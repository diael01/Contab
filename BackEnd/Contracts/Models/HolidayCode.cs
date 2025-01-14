namespace Contracts.Models;

public partial class HolidayCode
{
    public int Id { get; set; }

    public string? HolidayCode1 { get; set; }

    public string? HolidayDescription { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
