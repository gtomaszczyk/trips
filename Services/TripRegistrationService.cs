using Microsoft.EntityFrameworkCore;
using TripAPI.Common;
using TripAPI.Domain;
using TripAPI.Domain.Models;
using TripAPI.DTOs;

namespace TripAPI.Repositories
{
    public class TripRegistrationService(Context context)
    {
        private async Task<string?> VerifyUniqueEmailAsync(string email, int tripId)
        {
            return await context.TripRegistrations.AnyAsync(x => x.Email == email && x.TripId == tripId) ? $"Trip registration for email '{email}' already exist." : null;
        }

        private async Task<string?> VerifyTripExistsAsync(int tripId)
        {
            return await context.Trips.AllAsync(x => x.Id != tripId) ? $"Trip with id {tripId} does not exist." : null; 
        }

        public async Task<Result<int>> CreateAsync(CreateTripRegistrationDTO dto)
        {
            var error = (await Task.WhenAll(
                VerifyTripExistsAsync(dto.TripId), 
                VerifyUniqueEmailAsync(dto.Email, dto.TripId)
            )).FirstOrDefault(x => x != null);
            if (error != null) 
                return new Result<int>(new ErrorMessage(error));

            var entry = await context.TripRegistrations.AddAsync(new TripRegistration
            {
                Email = dto.Email,
                TripId = dto.TripId
            });
            await context.SaveChangesAsync();
            return new Result<int>(entry.Entity.Id);
        }
    }
}
