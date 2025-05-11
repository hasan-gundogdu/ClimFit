using ClimFit.Common.DTOs.External;

namespace ClimFit.Abstractions.Services
{
    public interface IAuthApiService
    {
        /// <summary>
        /// Returns the registered user's Id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<string?> RegisterUserAsync(UserRegisterDto request);
    }
}
