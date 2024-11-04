using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class IncreaseCode1
{
    public int Id { get; set; }

    public string? IncreaseCode { get; set; }

    public string? IncreaseDescription { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
