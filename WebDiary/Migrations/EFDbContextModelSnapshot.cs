﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebDiary.Data.EFContext;

namespace WebDiary.Migrations
{
    [DbContext(typeof(EFDbContext))]
    partial class EFDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebDiary.Data.EFContext.DbRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("WebDiary.Data.EFContext.DbUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("WebDiary.Data.EFContext.DbUserRole", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("WebDiary.Data.Models.Journal", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SubjectId");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Journals");
                });

            modelBuilder.Entity("WebDiary.Data.Models.Lesson", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cabinet");

                    b.Property<string>("Homework");

                    b.Property<string>("ScheduleId");

                    b.Property<string>("SubjectId");

                    b.Property<string>("Theme");

                    b.Property<string>("Time");

                    b.Property<int>("WeekDay");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("WebDiary.Data.Models.Mark", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("JournalId");

                    b.Property<int>("MarkType");

                    b.Property<string>("Status");

                    b.Property<string>("StudentId");

                    b.Property<DateTime>("TimeSet");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("JournalId");

                    b.HasIndex("StudentId");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("WebDiary.Data.Models.Parent", b =>
                {
                    b.Property<string>("Id");

                    b.HasKey("Id");

                    b.ToTable("Parents");
                });

            modelBuilder.Entity("WebDiary.Data.Models.Person", b =>
                {
                    b.Property<string>("Id");

                    b.Property<bool>("IsActive");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("WebDiary.Data.Models.Schedule", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SchoolClassId");

                    b.HasKey("Id");

                    b.HasIndex("SchoolClassId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("WebDiary.Data.Models.School", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("PersonId");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("WebDiary.Data.Models.SchoolClass", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime>("FinalDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<string>("SchoolId");

                    b.Property<string>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.HasIndex("TeacherId");

                    b.ToTable("SchoolClasses");
                });

            modelBuilder.Entity("WebDiary.Data.Models.SchoolClassStudent", b =>
                {
                    b.Property<string>("SchoolClassId");

                    b.Property<string>("StudentId");

                    b.HasKey("SchoolClassId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("SchoolClassStudent");
                });

            modelBuilder.Entity("WebDiary.Data.Models.SchoolWorker", b =>
                {
                    b.Property<string>("Id");

                    b.Property<bool>("IsDirector");

                    b.Property<string>("RoleDescription");

                    b.Property<string>("SchoolId");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("SchoolWorkers");
                });

            modelBuilder.Entity("WebDiary.Data.Models.Student", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ParentId");

                    b.Property<string>("SchoolId");

                    b.Property<string>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("SchoolId");

                    b.HasIndex("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("WebDiary.Data.Models.StudentSubject", b =>
                {
                    b.Property<string>("SubjectId");

                    b.Property<string>("StudentId");

                    b.HasKey("SubjectId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentSubject");
                });

            modelBuilder.Entity("WebDiary.Data.Models.Subject", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("SchoolClassId");

                    b.Property<string>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("SchoolClassId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("WebDiary.Data.Models.UserProfile", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(75);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(75);

                    b.Property<string>("Image")
                        .HasMaxLength(150);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(75);

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(75);

                    b.Property<DateTime>("RegistrationDate");

                    b.HasKey("Id");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("WebDiary.Data.EFContext.DbRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebDiary.Data.EFContext.DbUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebDiary.Data.EFContext.DbUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebDiary.Data.EFContext.DbUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebDiary.Data.EFContext.DbUserRole", b =>
                {
                    b.HasOne("WebDiary.Data.EFContext.DbRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebDiary.Data.EFContext.DbUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebDiary.Data.Models.Journal", b =>
                {
                    b.HasOne("WebDiary.Data.Models.Subject", "Subject")
                        .WithMany("Journals")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebDiary.Data.Models.Lesson", b =>
                {
                    b.HasOne("WebDiary.Data.Models.Schedule")
                        .WithMany("Lessons")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebDiary.Data.Models.Subject", "Subject")
                        .WithMany("Lessons")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebDiary.Data.Models.Mark", b =>
                {
                    b.HasOne("WebDiary.Data.Models.Journal", "Journal")
                        .WithMany("Marks")
                        .HasForeignKey("JournalId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebDiary.Data.Models.Student", "Student")
                        .WithMany("Marks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebDiary.Data.Models.Parent", b =>
                {
                    b.HasOne("WebDiary.Data.Models.UserProfile", "UserProfile")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebDiary.Data.Models.Person", b =>
                {
                    b.HasOne("WebDiary.Data.Models.UserProfile", "UserProfile")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebDiary.Data.Models.Schedule", b =>
                {
                    b.HasOne("WebDiary.Data.Models.SchoolClass", "SchoolClass")
                        .WithMany("Schedules")
                        .HasForeignKey("SchoolClassId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebDiary.Data.Models.School", b =>
                {
                    b.HasOne("WebDiary.Data.Models.Person")
                        .WithMany("Schools")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebDiary.Data.Models.SchoolClass", b =>
                {
                    b.HasOne("WebDiary.Data.Models.School", "School")
                        .WithMany("Classes")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebDiary.Data.Models.SchoolWorker", "Teacher")
                        .WithMany("Classes")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebDiary.Data.Models.SchoolClassStudent", b =>
                {
                    b.HasOne("WebDiary.Data.Models.SchoolClass", "SchoolClass")
                        .WithMany("SchoolClassStudents")
                        .HasForeignKey("SchoolClassId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebDiary.Data.Models.Student", "Student")
                        .WithMany("SchoolClassStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebDiary.Data.Models.SchoolWorker", b =>
                {
                    b.HasOne("WebDiary.Data.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebDiary.Data.Models.School")
                        .WithMany("SchoolWorkers")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebDiary.Data.Models.Student", b =>
                {
                    b.HasOne("WebDiary.Data.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebDiary.Data.Models.Parent", "Parent")
                        .WithMany("Kids")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebDiary.Data.Models.School")
                        .WithMany("Students")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebDiary.Data.Models.Student")
                        .WithMany("Siblings")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebDiary.Data.Models.StudentSubject", b =>
                {
                    b.HasOne("WebDiary.Data.Models.Student", "Student")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebDiary.Data.Models.Subject", "Subject")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebDiary.Data.Models.Subject", b =>
                {
                    b.HasOne("WebDiary.Data.Models.SchoolClass", "SchoolClass")
                        .WithMany("Subjects")
                        .HasForeignKey("SchoolClassId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebDiary.Data.Models.SchoolWorker", "Teacher")
                        .WithMany("Subjects")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebDiary.Data.Models.UserProfile", b =>
                {
                    b.HasOne("WebDiary.Data.EFContext.DbUser", "User")
                        .WithOne("UserProfile")
                        .HasForeignKey("WebDiary.Data.Models.UserProfile", "Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
