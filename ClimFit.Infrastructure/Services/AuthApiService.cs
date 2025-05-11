using ClimFit.Abstractions.Services;
using ClimFit.Common.DTOs.External;

namespace ClimFit.Infrastructure.Services
{
    public class AuthApiService : IAuthApiService
    {
        private readonly IHttpRequestBase _httpRequestBase;
        public AuthApiService(IHttpRequestBase httpRequestBase)
        {
            _httpRequestBase = httpRequestBase;
        }

        public async Task<string?> RegisterUserAsync(UserRegisterDto request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password) )
            {
                throw new ArgumentException("Email, Password are required.");
            }

            var response = await _httpRequestBase.SendAsync<string>(
                HttpMethod.Post,
                "https://demo-auth.infinextsoft.com/api/auth/register",
                new { email = request.Email, password = request.Password, redirectUrl = "http://climfit-api.infinextsoft.com/",
                    customClaims = new Dictionary<string, string>
                    {
                { "ClimFit", "ClimFit" }
                    }
                }
            );

            if (response == null)
            {
                throw new InvalidOperationException("Registration failed, response was null.");
            }

            return response;
        }
    }
}
