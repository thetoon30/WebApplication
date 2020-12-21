using System.Collections.Generic;
using WebApplication.Services.Models;

namespace WebApplication.Services.Abstract
{
    public interface IManufacturerService
    {
        List<ManufacturerModel> GetManufacturers();
        string GetManufacturerByModel(string model);
    }
}
