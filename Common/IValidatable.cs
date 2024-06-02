using Microsoft.AspNetCore.Mvc;

namespace TripAPI.Common
{
    public interface IValidatable
    {
        public ValidationErrors Validate();
    }
}
