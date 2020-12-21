using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.ExceptionServices;
using WebApplication.Services.Abstract;
using WebApplication.Services.Data;
using WebApplication.Services.Models;

namespace WebApplication.Services.Concrete
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IDataProvider _context;

        public ManufacturerService(IDataProvider context)
        {
            _context = context;
        }

        public List<ManufacturerModel> GetManufacturers()
        {
            var result = from a in _context.Manufacturers
                         join b in _context.Models on a.Id equals b.ManufacturerId
                         group a by new { a.Id, a.ManufacturerName } into ga
                         select new ManufacturerModel
                         {
                             Id = ga.Key.Id,
                             ManufacturerName = ga.Key.ManufacturerName,
                             NumberOfModel = ga.Count()
                         };

            return result.ToList();
        }

        public string GetManufacturerByModel(string model)
        {
            string result = (from a in _context.Manufacturers
                             join b in _context.Models on a.Id equals b.ManufacturerId
                             where b.ModelName == model
                             select a.ManufacturerName).FirstOrDefault();
            return result;
        }
    }
}