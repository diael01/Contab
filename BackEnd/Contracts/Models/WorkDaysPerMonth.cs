using System;
using System.Collections.Generic;

namespace Contracts.Models;

public partial class WorkDaysPerMonth
{
    public int Id { get; set; }

    public short Month { get; set; }

    public string? MonthName { get; set; }

    public short WorkDaysNo { get; set; }

    public short Year { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
