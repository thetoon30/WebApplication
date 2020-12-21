using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Services.Abstract;
using WebApplication.Services.Data;
using WebApplication.Services.Entities;
using WebApplication.Services.Models;

namespace WebApplication.Services.Concrete
{
    public class DataProvider: IDataProvider
    {
        private readonly ApiContext _context;

        public DataProvider(ApiContext context)
        {
            _context = context;
        }

        public List<Manufacturer> Manufacturers => _context.Manufacturers.ToList();

        public List<VehicleModel> Models => _context.Vehicles.ToList();
    }
}
