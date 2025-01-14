using Microsoft.EntityFrameworkCore;

namespace Contracts.Models;

public partial class Param
{
    public short Id { get; set; }

    public DateTime? ProcessingDate { get; set; }

    public string FiscalCode { get; set; } = null!;

    public decimal CaenCode { get; set; }

    public decimal AdvancePercentRate { get; set; }

    public short WorkRegime8Hours { get; set; }

    public short? NormatedRegime { get; set; }

    public string? Bank1Code { get; set; }

    public string? Bank2Code { get; set; }

    public string? CommerceRegister { get; set; }

    public short? NormalWorkHoursSchedule { get; set; }

    public decimal? MinimSalaryGovt { get; set; }

    public short? NoDaysForWhichAdvanceisPaid { get; set; }

    public string? EcnDirectorName { get; set; }

    public string? GenDirectorName { get; set; }

    public string? FinDirectorName { get; set; }

    public HierarchyId? EcnDirector { get; set; }

    public HierarchyId? GenDirector { get; set; }

    public HierarchyId? FinDirector { get; set; }

    public short? LiquidationDate { get; set; }

    public decimal? PercUnion { get; set; }

    public string? CodesRetention { get; set; }

    public decimal? PercSeniorityAddition { get; set; }

    public decimal? PercDifferentForPension { get; set; }

    public decimal? PercNormalForPension { get; set; }

    public decimal? PercSpecialForPension { get; set; }

    public decimal? BeneficiaryCode { get; set; }

    public decimal? InterestCar { get; set; }

    public decimal? TaxRate { get; set; }

    public decimal? PercSuplemDeduction { get; set; }

    public decimal? PercFixDeduction { get; set; }

    public decimal? PercLimited { get; set; }

    public decimal? PercDeducMedicalOoo { get; set; }

    public decimal? PercContribToWorkAccident { get; set; }

    public decimal? PercContribWorkInsurance { get; set; }

    public decimal? PercContribRetirement { get; set; }

    public decimal? PercHealthFund { get; set; }

    public decimal? PercUnemplPaidByPerson { get; set; }

    public decimal? PercUnemplPaidByCompany { get; set; }

    public decimal? DiminishingRegime { get; set; }

    public decimal? AlgorithmUnemplCalc1 { get; set; }

    public bool? ManualOrAutomatedOooCalc { get; set; }

    public decimal? BaseDeduction { get; set; }

    public decimal? TaxLimit { get; set; }

    public decimal? TaxLimitInf { get; set; }

    public decimal? TaxLimitSup { get; set; }

    public decimal? TaxLimitPercentProfictRealization { get; set; }

    public decimal? SalaryModification { get; set; }

    public decimal? AlgorithmCalculCas { get; set; }

    public decimal? HowToCalculateSalary { get; set; }

    public DateTime? UnionDay { get; set; }

    public DateTime? BigFriday { get; set; }

    public DateTime? Easter { get; set; }

    public DateTime? Rusali { get; set; }

    public DateTime? StMaria { get; set; }

    public DateTime? ChildDay { get; set; }

    public DateTime? StAndrei { get; set; }

    public decimal? MediumSalaryOnEconomy { get; set; }

    public string? PrecedentYearMonthlyWorkDays { get; set; }

    public string? CurrentYearMonthlyWorkDays { get; set; }

    public string? ApplicationVersion { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
