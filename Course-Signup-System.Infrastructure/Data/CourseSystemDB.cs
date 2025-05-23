﻿using Course_Signup_System.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Infrastructure.Data
{
    public class CourseSystemDB : DbContext
    {
        public CourseSystemDB(DbContextOptions<CourseSystemDB> options) : base(options) 
        {
        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<ClassOf> ClassOf { get; set; } = null!;
        public DbSet<Class> Classes { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<Faculty> Faculties { get; set; } = null!;
        public DbSet<StudentClass> StudentClasses { get; set; } = null!;
        public DbSet<GradeType> GradeTypes {  get; set; } = null!;
        public DbSet<SubjectClass> SubjectClasses { get; set; } = null!;
        public DbSet<SubjectGradeType> SubjectGradeTypes { get; set; } = null!;
        public DbSet<TeachSchedule> TeachSchedules { get; set; } = null!;
        public DbSet<SchoolHolidaySchedule> SchoolHolidaySchedules { get; set; } = null!;
        public DbSet<GradeColumn> GradeColumns { get; set; } = null!;
        public DbSet<PayTuition> PayTuitions { get; set; } = null!;
        public DbSet<TuitionType> TuitionTypes { get; set; } = null!;
        public DbSet<Grade> Grades { get; set; } = null!;
        public DbSet<EmployeeSalary> EmployeeSalaries { get; set; } = null!;
        public DbSet<Permission> Permissions { get; set; } = null!;
        public DbSet<RolePermission> RolePermissions { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Teacher>().HasIndex(T=> T.PhoneNumber).IsUnique();
            modelBuilder.Entity<Student>().HasIndex(s => s.PhoneNumber).IsUnique();
            modelBuilder.Entity<Teacher>().HasIndex(t=>t.IdentityCard ).IsUnique();

            modelBuilder.Entity<SubjectClass>()
                     .HasOne(sc => sc.Subject) 
                    .WithMany() 
                    .HasForeignKey(sc => sc.SubjectId)                    
                    .OnDelete(DeleteBehavior.NoAction); 
            modelBuilder.Entity<TeachSchedule>()
                    .HasOne(ts => ts.Subject) 
                   .WithMany()  
                   .HasForeignKey(ts => ts.SubjectId); 
            modelBuilder.Entity<TeachSchedule>()
                .HasOne(ts => ts.Subject)               // Mỗi TeachSchedule có một Subject
                .WithMany(s => s.TeachSchedules)        // Mỗi Subject có nhiều TeachSchedules
                .HasForeignKey(ts => ts.SubjectId)      // Khóa ngoại trong TeachSchedule là SubjectId         
                .OnDelete(DeleteBehavior.NoAction);     // Không thực hiện xóa cascade

            modelBuilder.Entity<SubjectClass>()
                .HasOne(ts => ts.Subject)               
                .WithMany(s => s.SubjectClasses)        
                .HasForeignKey(ts => ts.SubjectId)
                .OnDelete(DeleteBehavior.NoAction);     

        }

    }
}
