using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.Services.Data
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApiContext(serviceProvider.GetRequiredService<DbContextOptions<ApiContext>>()))
            {
                var manufacturers = Db.GetManufacturers();

                context.Manufacturers.AddRange(manufacturers);

                context.SaveChanges();

                var vehicles = Db.GetModels();

                context.Vehicles.AddRange(vehicles);

                context.SaveChanges();
            }
        }
    }
}
