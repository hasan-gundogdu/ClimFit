using ClimFit.Abstractions.Services;
using ClimFit.Common.Constants;
using ClimFit.Common.DTOs.External;

namespace ClimFit.Api.Controllers.ApiControllers
{
    [ApiController]
    [Route(ApplicationConstants.ApiRoutePrefix + "/[controller]")]
    public class UserApiController : ControllerBase
    {
        private readonly IAuthApiService _authApiService;
        public UserApiController(IAuthApiService authApiService)
        {
            _authApiService = authApiService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDto request)
        {
            try
            {
                var result = await _authApiService.RegisterUserAsync(request);
                if (result == null)
                {
                    return BadRequest("User registration failed.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
