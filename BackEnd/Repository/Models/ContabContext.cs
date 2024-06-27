using System;
using System.Collections.Generic;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Organisation>(entity =>
        {
            entity.HasKey(e => e.OrgNode).HasName("PK__Organisa__C1ECAF2ACF19B09D");

            entity.ToTable("Organisation");

            entity.HasIndex(e => new { e.OrgLevel, e.OrgNode }, "Org_BreadthFirst");

            entity.Property(e => e.CodGrm)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(32);
            entity.Property(e => e.Location)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.LongName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(32);
            entity.Property(e => e.OrgLevel).HasComputedColumnSql("([OrgNode].[GetLevel]())", false);
            entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(32);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
