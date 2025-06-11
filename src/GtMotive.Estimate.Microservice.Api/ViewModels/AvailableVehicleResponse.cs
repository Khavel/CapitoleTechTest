using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.ViewModels
{
    /// <summary>
    /// View model representing a vehicle in the list of available ones.
    /// </summary>
    public sealed class AvailableVehicleResponse
    {
        public AvailableVehicleResponse(string id, string brand, string model, int year)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
        }

        [Required]
        public string Id { get; }

        [Required]
        public string Brand { get; }

        [Required]
        public string Model { get; }

        [Required]
        public int Year { get; }
    }
}
