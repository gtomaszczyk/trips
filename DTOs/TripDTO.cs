namespace TripAPI.DTOs
{
    public class TripDTO
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Country { get; set; }
        public DateTime? StartDate { get; set; }
        public string? Description { get; set; }
        public int? NumberOfSeats { get; set; }
    }
}
