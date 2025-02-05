﻿// <auto-generated />
using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(VersionMmanagementSystemContext))]
    [Migration("20240918181315_UpdateUsersTable")]
    partial class UpdateUsersTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Models.Branch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BranchId"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("RepositoryId")
                        .HasColumnType("int");

                    b.HasKey("BranchId")
                        .HasName("PK__Branches__3214EC079A5B680E");

                    b.HasIndex("RepositoryId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("DAL.Models.Merge", b =>
                {
                    b.Property<int>("MergeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MergeId"));

                    b.Property<DateTime>("MergedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("SourceBranchId")
                        .HasColumnType("int");

                    b.Property<int>("TargetBranchId")
                        .HasColumnType("int");

                    b.HasKey("MergeId")
                        .HasName("PK__Merges__3214EC07B7EC65BE");

                    b.HasIndex("SourceBranchId");

                    b.HasIndex("TargetBranchId");

                    b.ToTable("Merges");
                });

            modelBuilder.Entity("DAL.Models.Repository", b =>
                {
                    b.Property<int>("RepositoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RepositoryId"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RepositoryId")
                        .HasName("PK__Reposito__3214EC07DEFDFBA0");

                    b.HasIndex("UserId");

                    b.ToTable("Repositories");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UserId")
                        .HasName("PK__Users__3214EC07B0BB39F7");

                    b.HasIndex(new[] { "Username" }, "UQ__Users__536C85E4ABBBBEAC")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "UQ__Users__A9D10534B773BA84")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DAL.Models.Version", b =>
                {
                    b.Property<int>("VersionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VersionId"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("VersionId")
                        .HasName("PK__Versions__3214EC07143246E9");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BranchId");

                    b.ToTable("Versions");
                });

            modelBuilder.Entity("DAL.Models.Branch", b =>
                {
                    b.HasOne("DAL.Models.Repository", "Repository")
                        .WithMany("Branches")
                        .HasForeignKey("RepositoryId")
                        .IsRequired()
                        .HasConstraintName("FK__Branches__Reposi__4222D4EF");

                    b.Navigation("Repository");
                });

            modelBuilder.Entity("DAL.Models.Merge", b =>
                {
                    b.HasOne("DAL.Models.Branch", "SourceBranch")
                        .WithMany("MergeSourceBranches")
                        .HasForeignKey("SourceBranchId")
                        .IsRequired()
                        .HasConstraintName("FK__Merges__SourceBr__4AB81AF0");

                    b.HasOne("DAL.Models.Branch", "TargetBranch")
                        .WithMany("MergeTargetBranches")
                        .HasForeignKey("TargetBranchId")
                        .IsRequired()
                        .HasConstraintName("FK__Merges__TargetBr__4BAC3F29");

                    b.Navigation("SourceBranch");

                    b.Navigation("TargetBranch");
                });

            modelBuilder.Entity("DAL.Models.Repository", b =>
                {
                    b.HasOne("DAL.Models.User", "User")
                        .WithMany("Repositories")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Repositor__User__3D5E1FD2");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.Version", b =>
                {
                    b.HasOne("DAL.Models.User", "Author")
                        .WithMany("Versions")
                        .HasForeignKey("AuthorId")
                        .IsRequired()
                        .HasConstraintName("FK__Versions__Author__46E78A0C");

                    b.HasOne("DAL.Models.Branch", "Branch")
                        .WithMany("Versions")
                        .HasForeignKey("BranchId")
                        .IsRequired()
                        .HasConstraintName("FK__Versions__Branch__45F365D3");

                    b.Navigation("Author");

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("DAL.Models.Branch", b =>
                {
                    b.Navigation("MergeSourceBranches");

                    b.Navigation("MergeTargetBranches");

                    b.Navigation("Versions");
                });

            modelBuilder.Entity("DAL.Models.Repository", b =>
                {
                    b.Navigation("Branches");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Navigation("Repositories");

                    b.Navigation("Versions");
                });
#pragma warning restore 612, 618
        }
    }
}
