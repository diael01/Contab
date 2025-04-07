using System;
using System.Collections.Generic;

namespace Contracts.Models;

public partial class RetainCode
{
    public int Id { get; set; }

    public string? RetainCode1 { get; set; }

    public string? RetainDescription { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
