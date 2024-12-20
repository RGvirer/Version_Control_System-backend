﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL.Models;

public partial class VersionMmanagementSystemContext : DbContext
{

    public VersionMmanagementSystemContext(DbContextOptions<VersionMmanagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Merge> Merges { get; set; }

    public virtual DbSet<Repository> Repositories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Version> Versions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.BranchId).HasName("PK__Branches__3214EC079A5B680E");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Repository).WithMany(p => p.Branches)
                .HasForeignKey(d => d.RepositoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Branches__Reposi__4222D4EF");
        });

        modelBuilder.Entity<Merge>(entity =>
        {
            entity.HasKey(e => e.MergeId).HasName("PK__Merges__3214EC07B7EC65BE");

            entity.Property(e => e.MergedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.SourceBranch).WithMany(p => p.MergeSourceBranches)
                .HasForeignKey(d => d.SourceBranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Merges__SourceBr__4AB81AF0");

            entity.HasOne(d => d.TargetBranch).WithMany(p => p.MergeTargetBranches)
                .HasForeignKey(d => d.TargetBranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Merges__TargetBr__4BAC3F29");
        });

        modelBuilder.Entity<Repository>(entity =>
        {
            entity.HasKey(e => e.RepositoryId).HasName("PK__Reposito__3214EC07DEFDFBA0");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.Repositories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Repositor__User__3D5E1FD2");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__3214EC07B0BB39F7");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E4ABBBBEAC").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534B773BA84").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(255);
            // מיפוי הקשר בין משתמשים לרפוזיטוריות
            entity.HasMany(e => e.Repositories) // מגדיר שמימוש של User יכול להיות קשור לרפוזיטוריות רבות
                  .WithOne(r => r.User) // כל רפוזיטוריון קשור למשתמש אחד
                  .HasForeignKey(r => r.UserId) // UserId ברפוזיטוריון הוא המפתח הזר
                  .OnDelete(DeleteBehavior.Cascade); // כאשר משתמש נמחק, כל הרפוזיטוריות שלו ימחקו


        });

        modelBuilder.Entity<Version>(entity =>
        {
            entity.HasKey(e => e.VersionId).HasName("PK__Versions__3214EC07143246E9");

            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);

            entity.HasOne(d => d.User).WithMany(p => p.Versions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Versions__Author__46E78A0C");

            entity.HasOne(d => d.Branch).WithMany(p => p.Versions)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Versions__Branch__45F365D3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
