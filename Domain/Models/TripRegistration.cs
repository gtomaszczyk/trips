namespace TripAPI.Domain.Models
{
    public class TripRegistration
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public int TripId { get; set; }
    }
}
