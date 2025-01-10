using Microsoft.EntityFrameworkCore;

namespace Contracts.Models;

public partial class Holiday
{
    public int Id { get; set; }

    public HierarchyId EmpNode { get; set; } = null!;

    public DateTime? EmpRecordChangeDate { get; set; }

    public DateTime? VacationStartDate { get; set; }

    public int? VacationStartDay { get; set; }

    public int? NumberofVacationDays { get; set; }

    public decimal? CalculationBase { get; set; }

    public string? IncreaseCode { get; set; }

    public decimal? IncreaseValue { get; set; }

    public decimal? VacationValueGross { get; set; }

    public decimal? CalculatedTax { get; set; }

    public decimal? CalculatedContributionToRetirement { get; set; }

    public decimal? CalculatedContributionToHealth { get; set; }

    public decimal? CalculatedContributionToUnemployment { get; set; }

    public decimal? Retains { get; set; }

    public decimal? FinalNetValueVacationMoney { get; set; }

    public DateTime? CalculationDate { get; set; }

    public decimal? CurrentYearMonthlyWorkHours { get; set; }

    public decimal? ReCalculatedVacationValueNet { get; set; }

    public DateTime? DateWhenVacationIsIntroduced { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
