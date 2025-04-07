using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Contracts.Models;

public partial class Employee
{
    public int Id { get; set; }

    public HierarchyId? EmpNode { get; set; }

    public DateTime? EmpRecordChangeDate { get; set; }

    public string LastName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string? FirstName { get; set; }

    public string IdCardSerieNo { get; set; } = null!;

    public decimal IdCardCnp { get; set; }

    public DateTime LastIdCardCreationDate { get; set; }

    public string LastIdCardCreatedBy { get; set; } = null!;

    public decimal MainSalary { get; set; }

    public DateTime HiringDate { get; set; }

    public string EmpShift { get; set; } = null!;

    public string CountyCode { get; set; } = null!;

    public short WorkGroup { get; set; }

    public short HoursToWork { get; set; }

    public bool Retired { get; set; }

    public short? RetirementPilonGovt { get; set; }

    public string Studies { get; set; } = null!;

    public string? CivilStatus { get; set; }

    public bool? SignalDeduction { get; set; }

    public bool? SignalImpozit { get; set; }

    public bool? HealthExempted { get; set; }

    public bool? HealthExemptionReason { get; set; }

    public string WorkEmail { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public HierarchyId? EmpDeptNode { get; set; }

    public HierarchyId? EmpActivityNode { get; set; }

    public HierarchyId? EmpWorkTypeNode { get; set; }

    public HierarchyId? EmpFunctionNode { get; set; }

    public string? EmpDeptNodeName { get; set; }

    public string? EmpActivityNodeName { get; set; }

    public string? EmpWorkTypeNodeName { get; set; }

    public string? EmpFunctionNodeName { get; set; }

    public HierarchyId? ManagerNode { get; set; }

    public string? ManagerNodeName { get; set; }

    public string? PersonalEmail { get; set; }

    public string? Bank1Code { get; set; }

    public string? Iban1 { get; set; }

    public string? Bank2Code { get; set; }

    public string? Iban2 { get; set; }

    public string? Phone { get; set; }

    public decimal? MgmtSalaryIncrease { get; set; }

    public string? EndWorkCode { get; set; }

    public DateTime? EndWorkDate { get; set; }

    public decimal? WorkExperienceSalaryIncrease { get; set; }

    public DateTime? FirstJobHiringDate { get; set; }

    public string? Location { get; set; }

    public bool? MealTickets { get; set; }

    public bool? AdvanceOrLiquidaton { get; set; }

    public short? YearSeniority { get; set; }

    public short? MonthSeniority { get; set; }

    public bool? Insured { get; set; }

    public string? Insurance { get; set; }

    public string? RetirementSeniority { get; set; }

    public short? RetirementSupplement { get; set; }

    public short? RetirementExclusionReason { get; set; }

    public decimal? MoneyAdvance { get; set; }

    public short? ExceptedRetributionDays { get; set; }

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

    public short? CodRetentionAdvance { get; set; }

    public string? AdvanceDocumentNo { get; set; }

    public decimal? RateRetentionAdvance { get; set; }

    public DateTime? FundEnterDate { get; set; }

    public decimal? FundTax { get; set; }

    public decimal? FundTotal { get; set; }

    public decimal? MonthlyContributionToFound { get; set; }

    public DateTime? BorrowingDate { get; set; }

    public decimal? BorrowedHowMuch { get; set; }

    public decimal? ReturnedHowMuch { get; set; }

    public decimal? InterestOnBorrowed { get; set; }

    public decimal? InterestRestant { get; set; }

    public decimal? InterestNotCalculated { get; set; }

    public decimal? RateRetentionLiquidation { get; set; }

    public short? CodRetentionLiquidation { get; set; }

    public short? CodRetentionBeneficiary { get; set; }

    public short? LiquidationDocumentNo { get; set; }

    public DateTime? LiquidationDocumentDate { get; set; }

    public decimal? MonthlyRetentionRate { get; set; }

    public decimal? Penalty { get; set; }

    public decimal? LastRate { get; set; }

    public decimal? OtherRate { get; set; }

    public decimal? PriorityRate { get; set; }

    public string? IncreaseCode { get; set; }

    public decimal? Base { get; set; }

    public decimal? WorkQuantity { get; set; }

    public decimal? IncreaseValue { get; set; }

    public decimal? TotalIncreaseValue { get; set; }

    public string? IncreaseCode2 { get; set; }

    public decimal? Base2 { get; set; }

    public decimal? WorkQuantity2 { get; set; }

    public decimal? IncreaseValue2 { get; set; }

    public decimal? TotalIncreaseValue2 { get; set; }

    public string? IncreaseCode3 { get; set; }

    public decimal? Base3 { get; set; }

    public decimal? WorkQuantity3 { get; set; }

    public decimal? IncreaseValue3 { get; set; }

    public decimal? TotalIncreaseValue3 { get; set; }

    public string? IncreaseCode4 { get; set; }

    public decimal? Base4 { get; set; }

    public decimal? WorkQuantity4 { get; set; }

    public decimal? IncreaseValue4 { get; set; }

    public decimal? TotalIncreaseValue4 { get; set; }

    public decimal? SalinlocReplacementSalaryForWhichInCalculateTheIncrease { get; set; }

    public decimal? Ro1HourlyRegimeForIncreaseCalculations { get; set; }

    public decimal? Ro2HourlyRegimeForIncreaseCalculations { get; set; }

    public decimal? Ro3HourlyRegimeForIncreaseCalculations { get; set; }

    public decimal? Ro4HourlyRegimeForIncreaseCalculations { get; set; }

    public decimal? GrossBonus { get; set; }

    public decimal? NetBonus { get; set; }

    public DateTime? BonusPayDate { get; set; }

    public string? BonusType { get; set; }

    public decimal? ContributionToHealth { get; set; }

    public decimal? ContributinToRetirement { get; set; }

    public decimal? ContributionToUnemployment { get; set; }

    public decimal? TotalTaxOnAdvance { get; set; }

    public string? AllOrOnlyWomenOrOnlyMen { get; set; }

    public string? EmpNodeText { get; set; }

    public string? EmpNodeName { get; set; }

    public short? EmpLevel { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
