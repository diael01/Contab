using System;
using System.Collections.Generic;

namespace Contracts.Models;

public partial class IncreaseCode
{
    public int Id { get; set; }

    public string? IncreaseCode1 { get; set; }

    public string? IncreaseDescription { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
