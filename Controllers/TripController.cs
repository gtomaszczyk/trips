using Microsoft.AspNetCore.Mvc;
using TripAPI.Common;
using TripAPI.DTOs;
using TripAPI.Repositories;

namespace TripAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TripController(TripService service) : ControllerBase
    {
        [HttpGet]
        public IEnumerable<TripDTO> Get([FromQuery]GetTripsDTO dto)
        {
            return service.Get(dto);
        }

        [HttpPost]
        public async Task<Result<int>> Post(CreateTripDTO dto)
        {
            return await service.CreateAsync(dto);
        }

        [HttpPut]
        public async Task<Result> Put(EditTripDTO dto)
        {
            return await service.EditAsync(dto);
        }

        [HttpDelete]
        public async Task<Result> Delete(EntityDTO dto)
        {
            return await service.DeleteAsync(dto);
        }
    }
}
