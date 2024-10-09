using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public partial class Salary
{
    public int Id { get; set; }

    public HierarchyId EmpNode { get; set; } = null!;

    public int? RecordChangeDayHistory { get; set; }

    public int? Category { get; set; }

    public string? EmpGradation { get; set; }

    public decimal? MainSalary { get; set; }

    public decimal? MgmtSalaryIncrease { get; set; }

    public string? EndWorkCode { get; set; }

    public DateTime? EndWorkDate { get; set; }

    public HierarchyId EmpDeptNode { get; set; } = null!;

    public HierarchyId EmpActivityNode { get; set; } = null!;

    public HierarchyId EmpSubActivityNode { get; set; } = null!;

    public HierarchyId EmpFunctionNode { get; set; } = null!;

    public string EmpShift { get; set; } = null!;

    public int? HoursToWork { get; set; }

    public int? WorkGroup { get; set; }

    public decimal? WorkExperienceSalaryIncrease { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
