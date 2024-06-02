namespace TripAPI.DTOs
{
    public class EditTripDTO : CreateTripDTO
    {
        public required int Id { get; set; }
    }
}
