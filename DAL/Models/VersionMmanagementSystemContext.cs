using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class VersionMmanagementSystemContext : DbContext
{
    public VersionMmanagementSystemContext()
    {
    }

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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-U1QEHDF\\SQLEXPRESS;Initial Catalog=VersionMmanagementSystem;Integrated Security=True;Trust Server Certificate=True");

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

            entity.HasOne(d => d.Owner).WithMany(p => p.Repositories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Repositor__Owner__3D5E1FD2");
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
