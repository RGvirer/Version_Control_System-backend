using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class RivkiGvirerContext : DbContext
{
    public RivkiGvirerContext()
    {
    }

    public RivkiGvirerContext(DbContextOptions<RivkiGvirerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<GroupPermission> GroupPermissions { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserGroup> UserGroups { get; set; }

    public virtual DbSet<UserGroupMembership> UserGroupMemberships { get; set; }

    public virtual DbSet<UserPermission> UserPermissions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // אפשר לכתוב קוד זה כדי לא להחמיץ את מיקום ההגדרה אם האופציה לא הוזנה מראש
            // optionsBuilder.UseSqlServer("DefaultConnection");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__C22324228F6CB022");

            entity.Property(e => e.DepartmentId)
                .ValueGeneratedNever()
                .HasColumnName("department_id");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("department_name");
        });

        modelBuilder.Entity<GroupPermission>(entity =>
        {
            entity.HasKey(e => e.GroupPermissionId).HasName("PK__GroupPer__C351D90500E45863");

            entity.Property(e => e.GroupPermissionId).HasColumnName("GroupPermissionID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.PermissionId).HasColumnName("PermissionID");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupPermissions)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GroupPerm__Group__5441852A");

            entity.HasOne(d => d.Permission).WithMany(p => p.GroupPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GroupPerm__Permi__5535A963");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__4D5CE4761E487F46");

            entity.Property(e => e.PatientId)
                .ValueGeneratedNever()
                .HasColumnName("patient_id");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.PatientAge).HasColumnName("patient_age");
            entity.Property(e => e.PatientName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("patient_name");

            entity.HasOne(d => d.Department).WithMany(p => p.Patients)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Patients__depart__66603565");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PermissionId).HasName("PK__Permissi__EFA6FB0F265CB693");

            entity.HasIndex(e => e.PermissionName, "UQ__Permissi__0FFDA357CF03727F").IsUnique();

            entity.Property(e => e.PermissionId).HasColumnName("PermissionID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.PermissionName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACA6F27EC0");

            entity.HasIndex(e => e.UserName, "UQ__Users__C9F2845624EDA9CF").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<UserGroup>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK__UserGrou__149AF30AF206A5B0");

            entity.HasIndex(e => e.GroupName, "UQ__UserGrou__6EFCD43465472A9C").IsUnique();

            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.GroupName).HasMaxLength(50);
        });

        modelBuilder.Entity<UserGroupMembership>(entity =>
        {
            entity.HasKey(e => e.MembershipId).HasName("PK__UserGrou__92A78599714FE2BC");

            entity.Property(e => e.MembershipId).HasColumnName("MembershipID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Group).WithMany(p => p.UserGroupMemberships)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserGroup__Group__5629CD9C");

            entity.HasOne(d => d.User).WithMany(p => p.UserGroupMemberships)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserGroup__UserI__571DF1D5");
        });

        modelBuilder.Entity<UserPermission>(entity =>
        {
            entity.HasKey(e => e.UserPermissionId).HasName("PK__UserPerm__A90F88D2BFEDB4AD");

            entity.Property(e => e.UserPermissionId).HasColumnName("UserPermissionID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PermissionId).HasColumnName("PermissionID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Permission).WithMany(p => p.UserPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserPermi__Permi__5812160E");

            entity.HasOne(d => d.User).WithMany(p => p.UserPermissions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserPermi__UserI__59063A47");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
