using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public partial class ContabContext : DbContext
{
    public ContabContext()
    {
    }

    public ContabContext(DbContextOptions<ContabContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Organisation> Organisations { get; set; }

    public virtual DbSet<Parameter> Parameters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC074B042AAD");

            entity.ToTable("Employee");

            entity.HasIndex(e => new { e.EmpLevel, e.EmpNode }, "Emp_BreadthFirst");

            entity.Property(e => e.Bank1Code)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Bank1Iban).HasMaxLength(128);
            entity.Property(e => e.Bank2Code)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Bank2Iban).HasMaxLength(128);
            entity.Property(e => e.BaseCalculationTl)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("BaseCalculationTL");
            entity.Property(e => e.Birthday).HasColumnType("smalldatetime");
            entity.Property(e => e.BonusGrossSpecial).HasColumnType("money");
            entity.Property(e => e.BonusManagement).HasColumnType("money");
            entity.Property(e => e.BonusManagementPartial).HasColumnType("money");
            entity.Property(e => e.CivilStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ContractNoIndivAccord).HasMaxLength(128);
            entity.Property(e => e.CountyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.DaysOoogiven).HasColumnName("DaysOOOGiven");
            entity.Property(e => e.Email).HasMaxLength(128);
            entity.Property(e => e.EmpGradation)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EmpLevel).HasComputedColumnSql("([EmpNode].[GetLevel]())", false);
            entity.Property(e => e.EmpNodeAsName).HasMaxLength(128);
            entity.Property(e => e.EmpNodeAsText).HasMaxLength(128);
            entity.Property(e => e.EmpShift)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("Z")
                .IsFixedLength();
            entity.Property(e => e.EndWorkCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EndWorkDate).HasColumnType("smalldatetime");
            entity.Property(e => e.FirstJobHiringDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("F")
                .IsFixedLength();
            entity.Property(e => e.HiringDate)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.HoursOoogiven).HasColumnName("HoursOOOGiven");
            entity.Property(e => e.HoursToWork).HasDefaultValue((short)8);
            entity.Property(e => e.HoursWorkedInTl).HasColumnName("HoursWorkedInTL");
            entity.Property(e => e.IdCardCnp).HasMaxLength(128);
            entity.Property(e => e.IdCardSerieNo).HasMaxLength(128);
            entity.Property(e => e.Insurance).HasMaxLength(128);
            entity.Property(e => e.LastIdCardCreationDate).HasColumnType("smalldatetime");
            entity.Property(e => e.LeaveGross).HasColumnType("money");
            entity.Property(e => e.Location)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.MainSalary).HasColumnType("money");
            entity.Property(e => e.MgmtSalaryIncrease).HasColumnType("money");
            entity.Property(e => e.MoneyAdvance).HasColumnType("money");
            entity.Property(e => e.MoneyBonus).HasColumnType("money");
            entity.Property(e => e.MoneyFinancialAid).HasColumnType("money");
            entity.Property(e => e.MoneyGiftTicket).HasColumnType("money");
            entity.Property(e => e.MoneyGrossForOtherTimes).HasColumnType("money");
            entity.Property(e => e.MoneyLeaveLiquidation).HasColumnType("money");
            entity.Property(e => e.MoneyMealTickets).HasColumnType("money");
            entity.Property(e => e.MoneyPartialBonus).HasColumnType("money");
            entity.Property(e => e.MoneyPartialSalary).HasColumnType("money");
            entity.Property(e => e.Name).HasMaxLength(128);
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
            entity.Property(e => e.RetirementSeniority)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Studies).HasMaxLength(128);
            entity.Property(e => e.Surname).HasMaxLength(128);
            entity.Property(e => e.TaxCumulated).HasColumnType("money");
            entity.Property(e => e.UntaxedMoney).HasColumnType("money");
            entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(128);
            entity.Property(e => e.WorkEmail)
                .HasMaxLength(128)
                .HasDefaultValue("org@org.com");
            entity.Property(e => e.WorkExperienceSalaryIncrease).HasColumnType("money");
            entity.Property(e => e.WorkGroup).HasDefaultValue((short)3);
        });

        modelBuilder.Entity<Organisation>(entity =>
        {
            entity.HasKey(e => e.Node).HasName("PK__Organisa__7D8CACC0E29C5F96");

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
            entity.Property(e => e.NodeAsName).HasMaxLength(128);
            entity.Property(e => e.NodeAsText).HasMaxLength(128);
            entity.Property(e => e.NodeLevel).HasComputedColumnSql("([Node].[GetLevel]())", false);
            entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(128);
        });

        modelBuilder.Entity<Parameter>(entity =>
        {
            entity.Property(e => e.AlphabeticalValue).HasMaxLength(128);
            entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.Description).HasMaxLength(64);
            entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(128);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
