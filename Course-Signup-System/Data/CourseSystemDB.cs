using Course_Signup_System.Entities;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Data
{
    public class CourseSystemDB : DbContext
    {
        public CourseSystemDB(DbContextOptions<CourseSystemDB> options) : base(options) 
        {
        }
        public DbSet<User> Users {  get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ClassOf> TrainingCourses { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            modelBuilder.Entity<Student>().ToTable("Students");
          
        }
    }
}
