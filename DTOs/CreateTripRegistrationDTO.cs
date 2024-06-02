using TripAPI.Common;

namespace TripAPI.DTOs
{
    public class CreateTripRegistrationDTO : IValidatable
    {
        public required string Email { get; set; }
        public int TripId { get; set; }

        public virtual ValidationErrors Validate()
        {
            var errors = new ValidationErrors();
            return errors;
        }
    }
}
