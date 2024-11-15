using Course_Signup_System.Entities;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Data
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u=> u.PhoneNumber).IsUnique();
            modelBuilder.Entity<Teacher>().HasIndex(u=>u.IdentityCard ).IsUnique();

            modelBuilder.Entity<TeachSchedule>()
                     .Property(t => t.StudyTime)
                     .HasConversion(
                     v => v.ToString(),  // Convert TimeOnly to string
                     v => TimeOnly.Parse(v));  // Convert string back to TimeOnly
            modelBuilder.Entity<SubjectClass>()
                     .HasOne(sc => sc.Subject) // SubjectClass has one Subject
                    .WithMany()  // Assuming that the relationship is one-to-many
                    .HasForeignKey(sc => sc.SubjectId)
                    .OnDelete(DeleteBehavior.NoAction);  // Disable cascade delete for this relationship
            modelBuilder.Entity<TeachSchedule>()
                    .HasOne(ts => ts.Subject) // SubjectClass has one Subject
                   .WithMany()  // Assuming that the relationship is one-to-many
                   .HasForeignKey(ts => ts.SubjectId);  // Disable cascade delete for this relationship
            modelBuilder.Entity<TeachSchedule>()
                .HasOne(ts => ts.Subject)               // Mỗi TeachSchedule có một Subject
                .WithMany(s => s.TeachSchedules)        // Mỗi Subject có nhiều TeachSchedules
                .HasForeignKey(ts => ts.SubjectId)      // Khóa ngoại trong TeachSchedule là SubjectId
                .OnDelete(DeleteBehavior.Cascade)
                .OnDelete(DeleteBehavior.NoAction);     // Không thực hiện xóa cascade

            modelBuilder.Entity<SubjectClass>()
                .HasOne(ts => ts.Subject)               // 
                .WithMany(s => s.SubjectClasses)        
                .HasForeignKey(ts => ts.SubjectId)
                .OnDelete(DeleteBehavior.NoAction);     // Không thực hiện xóa cascade

        }

    }
}
