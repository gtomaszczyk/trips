using TripAPI.Common;

namespace TripAPI.DTOs
{
    public class GetTripsDTO : IValidatable
    {
        public string? Name {  get; set; } 
        public bool? IncludeAllDetails { get; set; }
        public string? CountrySearchPhrase { get; set; }

        public ValidationErrors Validate()
        {
            var errors = new ValidationErrors();
            if (CountrySearchPhrase != null && Name != null)
                errors.Add($"Both {nameof(Name)} and {nameof(CountrySearchPhrase)} cannot be set at the same time");
            return errors;
        }
    }
}
