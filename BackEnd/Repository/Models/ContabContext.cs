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

    public virtual DbSet<Salary> Salaries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpNode).HasName("PK__Employee__11EA28CCFAC420F8");

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
            entity.Property(e => e.Birthday).HasColumnType("smalldatetime");
            entity.Property(e => e.CivilStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CountyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.EmpLevel).HasComputedColumnSql("([EmpNode].[GetLevel]())", false);
            entity.Property(e => e.EmpNodeAsName).HasMaxLength(128);
            entity.Property(e => e.EmpNodeAsText).HasMaxLength(128);
            entity.Property(e => e.EmpShift)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("Z")
                .IsFixedLength();
            entity.Property(e => e.FirstHiringDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.HiringDate).HasColumnType("smalldatetime");
            entity.Property(e => e.IdCardCnp).HasMaxLength(128);
            entity.Property(e => e.IdCardSerieNo).HasMaxLength(128);
            entity.Property(e => e.Insurance).HasMaxLength(128);
            entity.Property(e => e.LastIdCardCreationDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Location)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(128);
            entity.Property(e => e.Phone).HasMaxLength(32);
            entity.Property(e => e.RetirementSeniority)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Studies).HasMaxLength(128);
            entity.Property(e => e.Surname).HasMaxLength(128);
            entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(128);

            entity.HasOne(d => d.ManagerNodeNavigation).WithMany(p => p.InverseManagerNodeNavigation)
                .HasForeignKey(d => d.ManagerNode)
                .HasConstraintName("FK_Employee_Employee");
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

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Salary__3214EC07BA6D1762");

            entity.ToTable("Salary");

            entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.EmpGradation)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
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
            entity.Property(e => e.MainSalary).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.MgmtSalaryIncrease).HasColumnType("numeric(8, 2)");
            entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(128);
            entity.Property(e => e.WorkExperienceSalaryIncrease).HasColumnType("numeric(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
