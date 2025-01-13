using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Contracts.Models;

public partial class ContabContext : DbContext
{
    public ContabContext()
    {
    }

    public ContabContext(DbContextOptions<ContabContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<CodCor> CodCors { get; set; }

    public virtual DbSet<CodesPerCountry> CodesPerCountries { get; set; }

    public virtual DbSet<Disease> Diseases { get; set; }

    public virtual DbSet<DiseaseCode> DiseaseCodes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Holiday> Holidays { get; set; }

    public virtual DbSet<IncreaseCode> IncreaseCodes { get; set; }

    public virtual DbSet<MonthlyWorkDay> MonthlyWorkDays { get; set; }

    public virtual DbSet<Organisation> Organisations { get; set; }

    public virtual DbSet<Param> Params { get; set; }

    public virtual DbSet<Retain> Retains { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bank>(entity =>
        {
            entity.ToTable("Bank");

            entity.Property(e => e.Adress).HasMaxLength(128);
            entity.Property(e => e.BankCode).HasMaxLength(32);
            entity.Property(e => e.Iban).HasMaxLength(128);
        });

        modelBuilder.Entity<CodCor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CodCor");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<CodesPerCountry>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CodesPerCountry");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Disease>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Disease__3214EC0727D6F904");

            entity.ToTable("Disease");

            entity.Property(e => e.ChildCnp).HasColumnType("numeric(13, 0)");
            entity.Property(e => e.ContagiousCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.DateMedicalCertificate).HasColumnType("smalldatetime");
            entity.Property(e => e.DoctorLicenseNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EmpRecordChangeDate).HasColumnType("smalldatetime");
            entity.Property(e => e.EndDateOfTheDisease).HasColumnType("smalldatetime");
            entity.Property(e => e.MedCertificateCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MedCertificateCodeContinue)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MedCertificateNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MedCertificateNumberContinued)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MedCertificateSerie)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MedCertificateSerieContinued)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NetSalaryOnTheLast12Months).HasColumnType("money");
            entity.Property(e => e.NetSalaryPerDayOnTheLast12Months).HasColumnType("money");
            entity.Property(e => e.OtherPersonInCareCnp).HasColumnType("numeric(13, 0)");
            entity.Property(e => e.StartDateOfTheDisease).HasColumnType("smalldatetime");
            entity.Property(e => e.StartDateofMedicalHoliday).HasColumnType("smalldatetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(128);
            entity.Property(e => e.UrgencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<DiseaseCode>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.DiseaseCode1)
                .HasMaxLength(8)
                .HasColumnName("DiseaseCode");
            entity.Property(e => e.DiseaseDescription).HasMaxLength(128);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(128);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC0785D387F0");

            entity.ToTable("Employee");

            entity.HasIndex(e => new { e.EmpLevel, e.EmpNode }, "Emp_BreadthFirst");

            entity.Property(e => e.AdvanceDocumentNo).HasMaxLength(128);
            entity.Property(e => e.AllOrOnlyWomenOrOnlyMen)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Bank1Code)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Bank2Code)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Base).HasColumnType("money");
            entity.Property(e => e.Base2).HasColumnType("money");
            entity.Property(e => e.Base3).HasColumnType("money");
            entity.Property(e => e.Base4).HasColumnType("money");
            entity.Property(e => e.BaseCalculationTl)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("BaseCalculationTL");
            entity.Property(e => e.Birthday).HasColumnType("smalldatetime");
            entity.Property(e => e.BonusGrossSpecial).HasColumnType("money");
            entity.Property(e => e.BonusManagement).HasColumnType("money");
            entity.Property(e => e.BonusManagementPartial).HasColumnType("money");
            entity.Property(e => e.BonusPayDate).HasColumnType("smalldatetime");
            entity.Property(e => e.BonusType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BorrowedHowMuch).HasColumnType("money");
            entity.Property(e => e.BorrowingDate).HasColumnType("smalldatetime");
            entity.Property(e => e.CivilStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ContractNoIndivAccord).HasMaxLength(128);
            entity.Property(e => e.ContributinToRetirement).HasColumnType("money");
            entity.Property(e => e.ContributionToHealth).HasColumnType("money");
            entity.Property(e => e.ContributionToUnemployment).HasColumnType("money");
            entity.Property(e => e.CountyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.DaysOoogiven).HasColumnName("DaysOOOGiven");
            entity.Property(e => e.Email).HasMaxLength(128);
            entity.Property(e => e.EmpActivityNodeName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.EmpDeptNodeName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.EmpFunctionNodeName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.EmpLevel).HasComputedColumnSql("([EmpNode].[GetLevel]())", false);
            entity.Property(e => e.EmpNodeName).HasMaxLength(128);
            entity.Property(e => e.EmpNodeText).HasMaxLength(128);
            entity.Property(e => e.EmpRecordChangeDate).HasColumnType("smalldatetime");
            entity.Property(e => e.EmpShift)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("Z")
                .IsFixedLength();
            entity.Property(e => e.EmpWorkTypeNodeName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.EndWorkCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EndWorkDate).HasColumnType("smalldatetime");
            entity.Property(e => e.FirstJobHiringDate).HasColumnType("smalldatetime");
            entity.Property(e => e.FundEnterDate).HasColumnType("smalldatetime");
            entity.Property(e => e.FundTax).HasColumnType("money");
            entity.Property(e => e.FundTotal).HasColumnType("money");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("F")
                .IsFixedLength();
            entity.Property(e => e.GrossBonus).HasColumnType("money");
            entity.Property(e => e.HealthExempted).HasDefaultValue(false);
            entity.Property(e => e.HealthExemptionReason).HasDefaultValue(false);
            entity.Property(e => e.HiringDate)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.HoursOoogiven).HasColumnName("HoursOOOGiven");
            entity.Property(e => e.HoursToWork).HasDefaultValue((short)8);
            entity.Property(e => e.HoursWorkedInTl).HasColumnName("HoursWorkedInTL");
            entity.Property(e => e.Iban1)
                .HasMaxLength(24)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Iban2)
                .HasMaxLength(24)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IdCardCnp).HasColumnType("numeric(13, 0)");
            entity.Property(e => e.IdCardSerieNo).HasMaxLength(128);
            entity.Property(e => e.IncreaseCode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IncreaseCode2)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IncreaseCode3)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IncreaseCode4)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IncreaseValue).HasColumnType("money");
            entity.Property(e => e.IncreaseValue2).HasColumnType("money");
            entity.Property(e => e.IncreaseValue3).HasColumnType("money");
            entity.Property(e => e.IncreaseValue4).HasColumnType("money");
            entity.Property(e => e.Insurance).HasMaxLength(128);
            entity.Property(e => e.InterestNotCalculated).HasColumnType("money");
            entity.Property(e => e.InterestOnBorrowed).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.InterestRestant).HasColumnType("money");
            entity.Property(e => e.LastIdCardCreatedBy).HasColumnType("smalldatetime");
            entity.Property(e => e.LastIdCardCreationDate).HasColumnType("smalldatetime");
            entity.Property(e => e.LastRate).HasColumnType("money");
            entity.Property(e => e.LeaveGross).HasColumnType("money");
            entity.Property(e => e.LiquidationDocumentDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Location)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.MainSalary).HasColumnType("money");
            entity.Property(e => e.MealTickets).HasDefaultValue(false);
            entity.Property(e => e.MgmtSalaryIncrease)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.MoneyAdvance).HasColumnType("money");
            entity.Property(e => e.MoneyBonus).HasColumnType("money");
            entity.Property(e => e.MoneyFinancialAid).HasColumnType("money");
            entity.Property(e => e.MoneyGiftTicket).HasColumnType("money");
            entity.Property(e => e.MoneyGrossForOtherTimes).HasColumnType("money");
            entity.Property(e => e.MoneyLeaveLiquidation).HasColumnType("money");
            entity.Property(e => e.MoneyMealTickets).HasColumnType("money");
            entity.Property(e => e.MoneyPartialBonus).HasColumnType("money");
            entity.Property(e => e.MoneyPartialSalary).HasColumnType("money");
            entity.Property(e => e.MonthlyContributionToFound).HasColumnType("money");
            entity.Property(e => e.MonthlyRetentionRate).HasColumnType("money");
            entity.Property(e => e.Name).HasMaxLength(128);
            entity.Property(e => e.NetBonus).HasColumnType("money");
            entity.Property(e => e.OtherRate).HasColumnType("money");
            entity.Property(e => e.Penalty).HasColumnType("money");
            entity.Property(e => e.PercentDecreaseTl)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("PercentDecreaseTL");
            entity.Property(e => e.PercentDecreasecreaseIndivAccord).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.PercentDiminishQuantitative).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.PercentDimishFinal).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.PercentIncreaseIndivAccord).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.PercentIncreaseTl)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("PercentIncreaseTL");
            entity.Property(e => e.Phone).HasMaxLength(128);
            entity.Property(e => e.PriorityRate).HasColumnType("money");
            entity.Property(e => e.RateRetentionAdvance).HasColumnType("money");
            entity.Property(e => e.RateRetentionLiquidation).HasColumnType("money");
            entity.Property(e => e.RetirementPilonGovt).HasDefaultValue((short)0);
            entity.Property(e => e.RetirementSeniority)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ReturnedHowMuch).HasColumnType("money");
            entity.Property(e => e.Ro1HourlyRegimeForIncreaseCalculations)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("RO1_HourlyRegimeForIncreaseCalculations");
            entity.Property(e => e.Ro2HourlyRegimeForIncreaseCalculations)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("RO2_HourlyRegimeForIncreaseCalculations");
            entity.Property(e => e.Ro3HourlyRegimeForIncreaseCalculations)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("RO3_HourlyRegimeForIncreaseCalculations");
            entity.Property(e => e.Ro4HourlyRegimeForIncreaseCalculations)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("RO4_HourlyRegimeForIncreaseCalculations");
            entity.Property(e => e.SalinlocReplacementSalaryForWhichInCalculateTheIncrease)
                .HasColumnType("numeric(18, 1)")
                .HasColumnName("SALINLOC_ReplacementSalaryForWhichInCalculateTheIncrease");
            entity.Property(e => e.SignalDeduction).HasDefaultValue(true);
            entity.Property(e => e.SignalImpozit).HasDefaultValue(false);
            entity.Property(e => e.Studies)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Surname).HasMaxLength(128);
            entity.Property(e => e.TaxCumulated).HasColumnType("money");
            entity.Property(e => e.TotalIncreaseValue).HasColumnType("money");
            entity.Property(e => e.TotalIncreaseValue2).HasColumnType("money");
            entity.Property(e => e.TotalIncreaseValue3).HasColumnType("money");
            entity.Property(e => e.TotalIncreaseValue4).HasColumnType("money");
            entity.Property(e => e.TotalTaxOnAdvance).HasColumnType("money");
            entity.Property(e => e.UntaxedMoney).HasColumnType("money");
            entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(128);
            entity.Property(e => e.WorkEmail)
                .HasMaxLength(128)
                .HasDefaultValue("email@org.com");
            entity.Property(e => e.WorkExperienceSalaryIncrease)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.WorkGroup).HasDefaultValue((short)3);
            entity.Property(e => e.WorkQuantity).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.WorkQuantity2).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.WorkQuantity3).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.WorkQuantity4).HasColumnType("numeric(18, 0)");
        });

        modelBuilder.Entity<Holiday>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Holiday__3214EC0713580E49");

            entity.ToTable("Holiday");

            entity.Property(e => e.CalculatedContributionToHealth).HasColumnType("money");
            entity.Property(e => e.CalculatedContributionToRetirement).HasColumnType("money");
            entity.Property(e => e.CalculatedContributionToUnemployment).HasColumnType("money");
            entity.Property(e => e.CalculatedTax).HasColumnType("money");
            entity.Property(e => e.CalculationBase).HasColumnType("money");
            entity.Property(e => e.CalculationDate).HasColumnType("smalldatetime");
            entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.CurrentYearMonthlyWorkHours).HasColumnType("numeric(7, 3)");
            entity.Property(e => e.DateWhenVacationIsIntroduced).HasColumnType("smalldatetime");
            entity.Property(e => e.EmpRecordChangeDate).HasColumnType("smalldatetime");
            entity.Property(e => e.FinalNetValueVacationMoney).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.IncreaseCode)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IncreaseValue).HasColumnType("money");
            entity.Property(e => e.ReCalculatedVacationValueNet).HasColumnType("money");
            entity.Property(e => e.Retains).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(128);
            entity.Property(e => e.VacationStartDate).HasColumnType("smalldatetime");
            entity.Property(e => e.VacationValueGross).HasColumnType("money");
        });

        modelBuilder.Entity<IncreaseCode>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IncreaseCode1)
                .HasMaxLength(8)
                .HasColumnName("IncreaseCode");
            entity.Property(e => e.IncreaseDescription).HasMaxLength(128);
            entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(128);
        });

        modelBuilder.Entity<MonthlyWorkDay>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Organisation>(entity =>
        {
            entity.HasKey(e => e.Node).HasName("PK__Organisa__7D8CACC07F8A4BA6");

            entity.ToTable("Organisation");

            entity.HasIndex(e => new { e.NodeLevel, e.Node }, "Org_BreadthFirst");

            entity.Property(e => e.CodGrm)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CountyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.Location)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(128);
            entity.Property(e => e.NodeLevel).HasComputedColumnSql("([Node].[GetLevel]())", false);
            entity.Property(e => e.NodeName).HasMaxLength(128);
            entity.Property(e => e.NodeText).HasMaxLength(128);
            entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(128);
        });

        modelBuilder.Entity<Param>(entity =>
        {
            entity.Property(e => e.AdvancePercentRate).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.AlgorithmCalculCas)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("AlgorithmCalculCAS");
            entity.Property(e => e.AlgorithmUnemplCalc1).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.ApplicationVersion).HasMaxLength(128);
            entity.Property(e => e.Bank1Code).HasMaxLength(64);
            entity.Property(e => e.Bank2Code).HasMaxLength(64);
            entity.Property(e => e.BaseDeduction).HasColumnType("money");
            entity.Property(e => e.BeneficiaryCode).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.BigFriday).HasColumnType("smalldatetime");
            entity.Property(e => e.CaenCode).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.ChildDay).HasColumnType("smalldatetime");
            entity.Property(e => e.CodesRetention).HasMaxLength(64);
            entity.Property(e => e.CommerceRegister).HasMaxLength(64);
            entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.CurrentYearMonthlyWorkDays).HasMaxLength(64);
            entity.Property(e => e.DiminishingRegime).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Easter).HasColumnType("smalldatetime");
            entity.Property(e => e.EcnDirectorName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.FinDirectorName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.FiscalCode).HasMaxLength(32);
            entity.Property(e => e.GenDirectorName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.HowToCalculateSalary).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.InterestCar)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("InterestCAR");
            entity.Property(e => e.ManualOrAutomatedOooCalc).HasColumnName("ManualOrAutomated_OOO_Calc");
            entity.Property(e => e.MediumSalaryOnEconomy).HasColumnType("money");
            entity.Property(e => e.MinimSalaryGovt).HasColumnType("money");
            entity.Property(e => e.PercContribRetirement).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.PercContribToWorkAccident).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.PercContribWorkInsurance).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.PercDeducMedicalOoo)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("PercDeducMedicalOOO");
            entity.Property(e => e.PercDifferentForPension).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.PercFixDeduction).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.PercHealthFund).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.PercLimited).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.PercNormalForPension).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.PercSeniorityAddition).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.PercSpecialForPension).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.PercSuplemDeduction).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.PercUnemplPaidByCompany).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.PercUnemplPaidByPerson).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.PercUnion).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.PrecedentYearMonthlyWorkDays).HasMaxLength(64);
            entity.Property(e => e.ProcessingDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Rusali).HasColumnType("smalldatetime");
            entity.Property(e => e.SalaryModification).HasColumnType("money");
            entity.Property(e => e.StAndrei).HasColumnType("smalldatetime");
            entity.Property(e => e.StMaria).HasColumnType("smalldatetime");
            entity.Property(e => e.TaxLimit).HasColumnType("money");
            entity.Property(e => e.TaxLimitInf).HasColumnType("money");
            entity.Property(e => e.TaxLimitPercentProfictRealization).HasColumnType("money");
            entity.Property(e => e.TaxLimitSup).HasColumnType("money");
            entity.Property(e => e.TaxRate).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.UnionDay).HasColumnType("smalldatetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(128);
        });

        modelBuilder.Entity<Retain>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
