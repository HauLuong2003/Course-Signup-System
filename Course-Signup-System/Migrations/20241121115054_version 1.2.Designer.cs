﻿// <auto-generated />
using System;
using Course_Signup_System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Course_Signup_System.Migrations
{
    [DbContext(typeof(CourseSystemDB))]
    [Migration("20241121115054_version 1.2")]
    partial class version12
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Course_Signup_System.Entities.Class", b =>
                {
                    b.Property<string>("ClassId")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Avatar")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ClassOfId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FacultyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("MaxNumberStudent")
                        .HasColumnType("int");

                    b.Property<int>("NumberStudent")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<double>("Tuition")
                        .HasColumnType("float");

                    b.HasKey("ClassId");

                    b.HasIndex("ClassOfId");

                    b.HasIndex("FacultyId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.ClassOf", b =>
                {
                    b.Property<string>("ClassOfId")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ClassOfName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("EndStudy")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartStudy")
                        .HasColumnType("datetime2");

                    b.HasKey("ClassOfId");

                    b.ToTable("ClassOf");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.EmployeeSalary", b =>
                {
                    b.Property<int>("EmployeeSalaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeSalaryId"), 1L, 1);

                    b.Property<double>("Allowance")
                        .HasColumnType("float");

                    b.Property<double>("AllowanceName")
                        .HasColumnType("float");

                    b.Property<bool>("IsClose")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<double>("SalaryReal")
                        .HasColumnType("float");

                    b.Property<string>("TeacherUserId")
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeSalaryId");

                    b.HasIndex("TeacherUserId");

                    b.ToTable("EmployeeSalary");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.Faculty", b =>
                {
                    b.Property<string>("FacultyId")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FacultyName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("FacultyId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradeId"), 1L, 1);

                    b.Property<int>("GradeTypeId")
                        .HasColumnType("int");

                    b.Property<string>("SubjectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("GradeId");

                    b.HasIndex("GradeTypeId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.GradeColumn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.ToTable("GradeColumns");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.GradeType", b =>
                {
                    b.Property<int>("GradeTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradeTypeId"), 1L, 1);

                    b.Property<int>("Coefficient")
                        .HasColumnType("int");

                    b.Property<string>("GradeTypeName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("GradeTypeId");

                    b.ToTable("GradeTypes");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.PayTuition", b =>
                {
                    b.Property<int>("PayTuitionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PayTuitionId"), 1L, 1);

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentClassId")
                        .HasColumnType("int");

                    b.Property<double>("Surcharge")
                        .HasColumnType("float");

                    b.Property<double>("Tuition")
                        .HasColumnType("float");

                    b.Property<int>("TuitionTypeId")
                        .HasColumnType("int");

                    b.HasKey("PayTuitionId");

                    b.HasIndex("StudentClassId");

                    b.HasIndex("TuitionTypeId");

                    b.ToTable("PayTuitions");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.SchoolHolidaySchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameHoliday")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SchoolHolidaySchedules");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.StudentClass", b =>
                {
                    b.Property<int>("StudentClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentClassId"), 1L, 1);

                    b.Property<string>("ClassId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("StudentClassId");

                    b.HasIndex("ClassId");

                    b.HasIndex("UserId");

                    b.ToTable("StudentClasses");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.Subject", b =>
                {
                    b.Property<string>("SubjectId")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FacultyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SubjectId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("FacultyId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.SubjectClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClassId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsClose")
                        .HasColumnType("bit");

                    b.Property<string>("SubjectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("SubjectClasses");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.SubjectGradeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClassOfId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("GradeColumn")
                        .HasColumnType("int");

                    b.Property<int>("GradeTypeId")
                        .HasColumnType("int");

                    b.Property<int>("MandatoryColumnGrade")
                        .HasColumnType("int");

                    b.Property<string>("SubjectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ClassOfId");

                    b.HasIndex("GradeTypeId");

                    b.HasIndex("SubjectId");

                    b.ToTable("SubjectGradeTypes");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.TeachSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClassId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudyDay")
                        .HasColumnType("int");

                    b.Property<string>("StudyTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("UserId");

                    b.ToTable("TeachSchedules");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.TuitionType", b =>
                {
                    b.Property<int>("TuitionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TuitionTypeId"), 1L, 1);

                    b.Property<string>("TuitionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TuitionTypeId");

                    b.ToTable("TuitionTypes");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Avatar")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.Student", b =>
                {
                    b.HasBaseType("Course_Signup_System.Entities.User");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Parents")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasIndex("PhoneNumber")
                        .IsUnique()
                        .HasFilter("[PhoneNumber] IS NOT NULL");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("Course_Signup_System.Entities.Teacher", b =>
                {
                    b.HasBaseType("Course_Signup_System.Entities.User");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdentityCard")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("MainTeachingSubject")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PartTimeSubject")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("TaxCode")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasIndex("IdentityCard")
                        .IsUnique()
                        .HasFilter("[IdentityCard] IS NOT NULL");

                    b.HasIndex("PhoneNumber")
                        .IsUnique()
                        .HasFilter("[PhoneNumber] IS NOT NULL");

                    b.ToTable("Teachers", (string)null);
                });

            modelBuilder.Entity("Course_Signup_System.Entities.Class", b =>
                {
                    b.HasOne("Course_Signup_System.Entities.ClassOf", "ClassOf")
                        .WithMany()
                        .HasForeignKey("ClassOfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Course_Signup_System.Entities.Faculty", "Faculty")
                        .WithMany("Class")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassOf");

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.EmployeeSalary", b =>
                {
                    b.HasOne("Course_Signup_System.Entities.Teacher", "Teacher")
                        .WithMany("EmployeeSalarys")
                        .HasForeignKey("TeacherUserId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.Grade", b =>
                {
                    b.HasOne("Course_Signup_System.Entities.GradeType", "GradeType")
                        .WithMany("Grade")
                        .HasForeignKey("GradeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Course_Signup_System.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Course_Signup_System.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GradeType");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.GradeColumn", b =>
                {
                    b.HasOne("Course_Signup_System.Entities.Grade", "Grade")
                        .WithMany("GradeColumns")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.PayTuition", b =>
                {
                    b.HasOne("Course_Signup_System.Entities.StudentClass", "StudentClass")
                        .WithMany("PayTuitions")
                        .HasForeignKey("StudentClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Course_Signup_System.Entities.TuitionType", "TuitionType")
                        .WithMany("PayTuitions")
                        .HasForeignKey("TuitionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentClass");

                    b.Navigation("TuitionType");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.StudentClass", b =>
                {
                    b.HasOne("Course_Signup_System.Entities.Class", "Class")
                        .WithMany("StudentClasses")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Course_Signup_System.Entities.Student", "Student")
                        .WithMany("StudentClasses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.Subject", b =>
                {
                    b.HasOne("Course_Signup_System.Entities.Department", "Department")
                        .WithMany("Subjects")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Course_Signup_System.Entities.Faculty", "Faculty")
                        .WithMany("Subjects")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.SubjectClass", b =>
                {
                    b.HasOne("Course_Signup_System.Entities.Class", "Class")
                        .WithMany("SubjectClasses")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Course_Signup_System.Entities.Department", "Department")
                        .WithMany("SubjectClasses")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Course_Signup_System.Entities.Subject", "Subject")
                        .WithMany("SubjectClasses")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Department");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.SubjectGradeType", b =>
                {
                    b.HasOne("Course_Signup_System.Entities.ClassOf", "ClassOf")
                        .WithMany("SubjectGradeTypes")
                        .HasForeignKey("ClassOfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Course_Signup_System.Entities.GradeType", "GradeType")
                        .WithMany("SubjectGradeType")
                        .HasForeignKey("GradeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Course_Signup_System.Entities.Subject", "Subject")
                        .WithMany("SubjectGradeTypes")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassOf");

                    b.Navigation("GradeType");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.TeachSchedule", b =>
                {
                    b.HasOne("Course_Signup_System.Entities.Class", "Class")
                        .WithMany("TeachSchedules")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Course_Signup_System.Entities.Subject", "Subject")
                        .WithMany("TeachSchedules")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Course_Signup_System.Entities.Teacher", "Teacher")
                        .WithMany("TeachSchedules")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.User", b =>
                {
                    b.HasOne("Course_Signup_System.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.Student", b =>
                {
                    b.HasOne("Course_Signup_System.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Course_Signup_System.Entities.Student", "UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Course_Signup_System.Entities.Teacher", b =>
                {
                    b.HasOne("Course_Signup_System.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Course_Signup_System.Entities.Teacher", "UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Course_Signup_System.Entities.Class", b =>
                {
                    b.Navigation("StudentClasses");

                    b.Navigation("SubjectClasses");

                    b.Navigation("TeachSchedules");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.ClassOf", b =>
                {
                    b.Navigation("SubjectGradeTypes");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.Department", b =>
                {
                    b.Navigation("SubjectClasses");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.Faculty", b =>
                {
                    b.Navigation("Class");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.Grade", b =>
                {
                    b.Navigation("GradeColumns");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.GradeType", b =>
                {
                    b.Navigation("Grade");

                    b.Navigation("SubjectGradeType");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.StudentClass", b =>
                {
                    b.Navigation("PayTuitions");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.Subject", b =>
                {
                    b.Navigation("SubjectClasses");

                    b.Navigation("SubjectGradeTypes");

                    b.Navigation("TeachSchedules");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.TuitionType", b =>
                {
                    b.Navigation("PayTuitions");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.Student", b =>
                {
                    b.Navigation("StudentClasses");
                });

            modelBuilder.Entity("Course_Signup_System.Entities.Teacher", b =>
                {
                    b.Navigation("EmployeeSalarys");

                    b.Navigation("TeachSchedules");
                });
#pragma warning restore 612, 618
        }
    }
}
