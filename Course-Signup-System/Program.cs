using AutoMapper;
using Course_Signup_System.Common.Mapping;
using Course_Signup_System.Data;
using Course_Signup_System.Entities;
using Course_Signup_System.Repositories;
using Course_Signup_System.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;

namespace Course_Signup_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CourseSystemDB>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")?? throw new InvalidOperationException("connection string not fouind"));
             });
            builder.Services.AddControllers()
           .AddJsonOptions(options =>
           {
               options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
           });
            builder.Services.AddAutoMapper(typeof(MapperProfile));
            builder.Services.AddScoped<IUserService, UserRepository>();
            builder.Services.AddScoped<IHashPasword, HashPasswordRepository>();
            builder.Services.AddScoped<IRoleService, RoleRepository>();
            builder.Services.AddScoped<IStudentService, StudentRepository>();
            builder.Services.AddScoped<ITeacherService, TeacherRepository>();
            builder.Services.AddScoped<GenerateService,GenerateRepository>();
            builder.Services.AddScoped<IAuthService,AuthRepository>();
            builder.Services.AddScoped<IClassOfService, ClassOfRepository>();
            builder.Services.AddScoped<IClassService, ClassRepository>();
            builder.Services.AddScoped<IFacultyService, FacultyRepository>();
            builder.Services.AddScoped<IStudentClassService,StudentClassRepository>();
            builder.Services.AddScoped<ISubjectService, SubjectRepository>();
            builder.Services.AddScoped<IDepartmentService, DepartmentRepository>();
            builder.Services.AddScoped<IFileStorageService, FileStorageRepository>();
            builder.Services.AddScoped<ISubjectClassService,SubjectClassRepository>();
            builder.Services.AddScoped<ITeacherScheduleService, TeacherScheduleRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
