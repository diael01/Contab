using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public partial class Employee
{
    public int Id { get; set; }

    public HierarchyId EmpNode { get; set; } = null!;

    public int EmpRecordChangeDay { get; set; }

    public string Name { get; set; } = null!;

    public string IdCardSerieNo { get; set; } = null!;

    public string IdCardCnp { get; set; } = null!;

    public DateTime LastIdCardCreationDate { get; set; }

    public decimal MainSalary { get; set; }

    public DateTime HiringDate { get; set; }

    public HierarchyId ManagerNode { get; set; } = null!;

    public string EmpShift { get; set; } = null!;

    public string CountyCode { get; set; } = null!;

    public short WorkGroup { get; set; }

    public short HoursToWork { get; set; }

    public short WorkTypeContract { get; set; }

    public string Email { get; set; } = null!;

    public string WorkEmail { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public HierarchyId EmpDeptNode { get; set; } = null!;

    public HierarchyId EmpActivityNode { get; set; } = null!;

    public HierarchyId EmpWorkTypeNode { get; set; } = null!;

    public HierarchyId EmpFunctionNode { get; set; } = null!;

    public bool Retired { get; set; }

    public string? Phone { get; set; }

    public string? Surname { get; set; }

    public short? Category { get; set; }

    public string? EmpGradation { get; set; }

    public string? CivilStatus { get; set; }

    public decimal? MgmtSalaryIncrease { get; set; }

    public string? EndWorkCode { get; set; }

    public DateTime? EndWorkDate { get; set; }

    public decimal? WorkExperienceSalaryIncrease { get; set; }

    public DateTime? FirstJobHiringDate { get; set; }

    public string? Location { get; set; }

    public bool? MealTickets { get; set; }

    public bool? AvansOrLiquidaton { get; set; }

    public short? YearSeniority { get; set; }

    public short? MonthSeniority { get; set; }

    public bool? Insured { get; set; }

    public string? Insurance { get; set; }

    public string? Studies { get; set; }

    public string? Bank1Code { get; set; }

    public string? Bank1Iban { get; set; }

    public string? Bank2Code { get; set; }

    public string? Bank2Iban { get; set; }

    public string? RetirementSeniority { get; set; }

    public short? RetirementSupplement { get; set; }

    public short? RetirementExclusionReason { get; set; }

    public short? RetirementPilonGovt { get; set; }

    public decimal? MoneyAdvance { get; set; }

    public short? HoursRegie { get; set; }

    public short? HoursOoogiven { get; set; }

    public short? HoursNotmotivatedAbsence { get; set; }

    public short? HoursInterruption { get; set; }

    public short? HoursInterruptionNotmotivated { get; set; }

    public short? HoursExcludedFromSeniorityAddition { get; set; }

    public short? DaysLeave { get; set; }

    public short? DaysLeaveWithoutPay { get; set; }

    public short? DaysSick { get; set; }

    public short? DaysUnmotivatedAbsence { get; set; }

    public short? DaysOoogiven { get; set; }

    public decimal? LeaveGross { get; set; }

    public decimal? MoneyLeaveLiquidation { get; set; }

    public decimal? MoneyFinancialAid { get; set; }

    public decimal? MoneyPartialSalary { get; set; }

    public decimal? MoneyBonus { get; set; }

    public decimal? MoneyPartialBonus { get; set; }

    public decimal? PercentDiminishQuantitative { get; set; }

    public decimal? PercentDimishFinal { get; set; }

    public decimal? MoneyGrossForOtherTimes { get; set; }

    public string? ContractNoIndivAccord { get; set; }

    public short? IndividualAcord { get; set; }

    public short? HoursIndivAccord { get; set; }

    public decimal? PercentIncreaseIndivAccord { get; set; }

    public decimal? PercentDecreasecreaseIndivAccord { get; set; }

    public short? HoursWorkedInTl { get; set; }

    public decimal? PercentIncreaseTl { get; set; }

    public decimal? PercentDecreaseTl { get; set; }

    public decimal? BaseCalculationTl { get; set; }

    public decimal? TaxCumulated { get; set; }

    public decimal? BonusGrossSpecial { get; set; }

    public decimal? BonusManagement { get; set; }

    public decimal? BonusManagementPartial { get; set; }

    public decimal? UntaxedMoney { get; set; }

    public short? HoursLeave { get; set; }

    public short? HoursLeaveWithoutPay { get; set; }

    public decimal? MoneyMealTickets { get; set; }

    public decimal? MoneyGiftTicket { get; set; }

    public short? NumberOfTickets { get; set; }

    public string? EmpNodeAsText { get; set; }

    public string? EmpNodeAsName { get; set; }

    public short? EmpLevel { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
