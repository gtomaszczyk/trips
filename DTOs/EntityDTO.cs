using TripAPI.Common;

namespace TripAPI.DTOs
{
    public class EntityDTO : IValidatable
    {
        public required int Id { get; set; }

        public ValidationErrors Validate()
        {
            var errors = new ValidationErrors();
            return errors;
        }
    }
}
