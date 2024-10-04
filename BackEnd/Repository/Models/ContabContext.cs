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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Contab;Trusted_Connection=True;TrustServerCertificate=True", x => x.UseHierarchyId());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpNode).HasName("PK__Employee__11EA28CC5C5E796A");

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
            entity.Property(e => e.EmpFunctionNodeName).HasMaxLength(128);
            entity.Property(e => e.EmpFunctionNodeText).HasMaxLength(128);
            entity.Property(e => e.EmpLevel).HasComputedColumnSql("([EmpNode].[GetLevel]())", false);
            entity.Property(e => e.EmpNodeText).HasMaxLength(128);
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
            entity.Property(e => e.ManagerNodeName).HasMaxLength(128);
            entity.Property(e => e.ManagerNodeText).HasMaxLength(128);
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

            entity.HasOne(d => d.EmpFunctionNodeNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmpFunctionNode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Organisation");

            entity.HasOne(d => d.ManagerNodeNavigation).WithMany(p => p.InverseManagerNodeNavigation)
                .HasForeignKey(d => d.ManagerNode)
                .HasConstraintName("FK_Employee_Employee");
        });

        modelBuilder.Entity<Organisation>(entity =>
        {
            entity.HasKey(e => e.OrgNode).HasName("PK__Organisa__C1ECAF2AAB25842F");

            entity.ToTable("Organisation");

            entity.HasIndex(e => new { e.OrgLevel, e.OrgNode }, "Org_BreadthFirst");

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
            entity.Property(e => e.OrgLevel).HasComputedColumnSql("([OrgNode].[GetLevel]())", false);
            entity.Property(e => e.OrgNodeText).HasMaxLength(128);
            entity.Property(e => e.ParentNodeName).HasMaxLength(128);
            entity.Property(e => e.ParentNodeText).HasMaxLength(128);
            entity.Property(e => e.Surname)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(128);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
