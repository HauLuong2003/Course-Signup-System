using Blazored.LocalStorage;
using Course_Signup_System.Application.DTO.Reponse;
using Course_Signup_System.Application.DTO.Request;
using Course_Signup_System.Application.Services;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Course_Signup_System.Presentation.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private string BaseUrl = "api/Auth";
        private readonly ILocalStorageService _localStorageService;
        private readonly CustomAuthProvider _customAuthProvider;
        public AuthService(HttpClient httpClient, ILocalStorageService localStorageService, CustomAuthProvider customAuthProvider) : base(httpClient)
        { 
            _localStorageService = localStorageService;
            _customAuthProvider = customAuthProvider;
        }
        public Task<string> ForgetPassword(ForgetPassword ForgetPassword)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Login(Login login)
        {
            var result = await _httpClient.PostAsync($"{BaseUrl}/Login", GenerateStringContent(SerializeObj(login)));
            if (result.IsSuccessStatusCode)
            {
                var token = await result.Content.ReadAsStringAsync();
                await _localStorageService.SetItemAsStringAsync("authToken", token);
                _customAuthProvider.NotifyUserAuthentication(token);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                return token;
            }
            return "Đăng nhập không thành công" ;
        }

        public Task<ServiceResponse> ResetPassword(ResetPassword ResetPassword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerificationToken(VerificationToken VerificationToken)
        {
            throw new NotImplementedException();
        }
    }
}
