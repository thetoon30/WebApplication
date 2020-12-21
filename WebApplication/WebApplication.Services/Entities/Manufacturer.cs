using System.Collections.Generic;

namespace WebApplication.Services.Entities
{
    public class Manufacturer
    {
        public string Id { get; set; }
        public string ManufacturerName { get; set; }

        public List<VehicleModel> Vehicles { get; set; }
    }
}