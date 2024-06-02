using Microsoft.AspNetCore.Mvc;

namespace TripAPI.Common
{
    public class ValidationErrors
    {
        public List<string> ErrorMessages { get; set; } = [];
        public void Add(string message)
        {
            ErrorMessages.Add(message);
        }
    }
}
