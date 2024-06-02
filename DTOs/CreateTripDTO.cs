using TripAPI.Common;

namespace TripAPI.DTOs
{
    public class CreateTripDTO : IValidatable
    {
        public required string Name { get; set; }
        public string? Country { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public int? NumberOfSeats { get; set; }
        public ValidationErrors Validate()
        {
            var errors = new ValidationErrors();
            if (Name.Length > 50)
                errors.Add("Maximum name length is 50");
            if (Country != null && Country.Length > 20)
                errors.Add("Maximum country length is 20");
            if (NumberOfSeats != null && NumberOfSeats > 100)
                errors.Add("Maximum number of seats is 100");
            return errors;
        }
    }
}
