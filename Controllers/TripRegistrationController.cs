using Microsoft.AspNetCore.Mvc;
using TripAPI.Common;
using TripAPI.DTOs;
using TripAPI.Repositories;

namespace TripAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TripRegistrationController(TripRegistrationService service) : ControllerBase
    {
        [HttpPost]
        public async Task<Result<int>> Post(CreateTripRegistrationDTO dto)
        {
            return await service.CreateAsync(dto);
        }
    }
}
