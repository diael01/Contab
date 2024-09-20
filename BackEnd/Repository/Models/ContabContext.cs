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

    public virtual DbSet<Organisation> Organisations { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Organisation>(entity =>
        {
            entity.HasKey(e => e.OrgNode).HasName("PK__Organisa__C1ECAF2A25B95E8C");

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
            entity.Property(e => e.LongName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(64);
            entity.Property(e => e.OrgLevel).HasComputedColumnSql("([OrgNode].[GetLevel]())", false);
            entity.Property(e => e.OrgNodeText).HasMaxLength(128);
            entity.Property(e => e.ParentNodeText).HasMaxLength(128);
            entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(128);
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.EmpNode).HasName("PK__Personal__11EA28CC8EB561CE");

            entity.ToTable("Personal");

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
            entity.Property(e => e.NameSurname).HasMaxLength(128);
            entity.Property(e => e.ParentNodeText).HasMaxLength(128);
            entity.Property(e => e.Phone).HasMaxLength(32);
            entity.Property(e => e.RetirementSeniority)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Studies).HasMaxLength(128);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
