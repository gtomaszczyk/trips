using Microsoft.EntityFrameworkCore;
using TripAPI.Common;
using TripAPI.Domain;
using TripAPI.Domain.Models;
using TripAPI.DTOs;

namespace TripAPI.Repositories
{
    public class TripService(Context context)
    {
        private async Task<string?> VerifyUniqueNameAsync(string name, int? editedTripId = null)
        {
            return await context.Trips.AnyAsync(x => x.Name == name && x.Id != editedTripId) ? $"Trip name '{name}' is already taken." : null;
        }
        public IEnumerable<TripDTO> Get(GetTripsDTO dto)
        {
            var queryable = context.Trips.AsQueryable();
            if (dto.CountrySearchPhrase != null)
            {
                queryable = queryable.Where(x => x.Country != null && x.Country.Contains(dto.CountrySearchPhrase));
            }
            if (dto.Name != null)
            {
                queryable = queryable.Where(x => x.Name ==  dto.Name);
            }
            if (dto.IncludeAllDetails == true)
            {
                return queryable.Select(x => new TripDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Country = x.Country,
                    StartDate = x.StartDate,
                    Description = x.Description,
                    NumberOfSeats = x.NumberOfSeats
                });
            } 
            else
            {
                return queryable.Select(x => new TripDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Country = x.Country,
                    StartDate = x.StartDate
                });
            }
        }

        public async Task<Result<int>> CreateAsync(CreateTripDTO dto)
        {
            var error = await VerifyUniqueNameAsync(dto.Name);
            if (error != null)
                return new Result<int>(new ErrorMessage(error));
            var entry = await context.Trips.AddAsync(new Trip
            {
                Name = dto.Name,
                Country = dto.Country,
                StartDate = dto.StartDate,
                Description = dto.Description,
                NumberOfSeats = dto.NumberOfSeats
            });
            await context.SaveChangesAsync();
            return new Result<int>(entry.Entity.Id);
        }

        public async Task<Result> EditAsync(EditTripDTO dto)
        {
            var error = await VerifyUniqueNameAsync(dto.Name, dto.Id);
            if (error != null)
                return new Result(new ErrorMessage(error));
            var entity = await context.Trips.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity != null)
            {
                context.Entry(entity).CurrentValues.SetValues(dto);
                await context.SaveChangesAsync();
                return new Result();
            }
            return new Result(new ErrorMessage($"Entity with id {dto.Id} not found"));
        }

        public async Task<Result> DeleteAsync(EntityDTO dto)
        {
            var entity = await context.Trips.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity != null)
            {
                context.Trips.Remove(entity);
                await context.SaveChangesAsync();
                return new Result();
            }
            return new Result(new ErrorMessage($"Entity with id {dto.Id} not found"));
        }


    }
}
