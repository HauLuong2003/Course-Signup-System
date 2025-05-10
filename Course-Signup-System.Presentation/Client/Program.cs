using Blazored.LocalStorage;
using Course_Signup_System.Application.Services;
using Course_Signup_System.Presentation;
using Course_Signup_System.Presentation.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;

namespace Course_Signup_System.Presentation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<CustomAuthProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
                  provider.GetRequiredService<CustomAuthProvider>());
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<IRoleService, RoleService>();   
            builder.Services.AddScoped<ITeacherService, TeacherService>();
            builder.Services.AddScoped<ISubjectService, SubjectService>();
            builder.Services.AddScoped<IFileStorageService, FileStorageService>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7067") });

            await builder.Build().RunAsync();
        }
    }
}
