using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using WebApplication.Services.Abstract;
using WebApplication.Services.Concrete;
using WebApplication.Services.Data;

namespace WebApplication.Services.Tests
{
    [TestFixture]
    public class ManufacturerServiceTests
    {

        private IManufacturerService _manufacturerService;

        public ManufacturerServiceTests()
        {
        }

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase());
            services.AddTransient<IDataProvider, DataProvider>();
            services.AddTransient<IManufacturerService, ManufacturerService>();

            var serviceProvider = services.BuildServiceProvider();
            DataGenerator.Initialize(serviceProvider);

            _manufacturerService = serviceProvider.GetService<IManufacturerService>();
        }

        //todo: fix test
        [TestCase("488GTB", "FERRARI")]
        [TestCase("A8ハイブリッド", "AUDI")]
        [TestCase("エテルナ", "MITSUBISHI")]
        [TestCase("スプリンタートレノ", "TOYOTA")]
        [TestCase("パサートGTEヴァリアント", "VOLKSWAGEN")]
        public void CanIdentifyManufacturer(string value, string expected)
        {
            var result = _manufacturerService.GetManufacturerByModel(value);
            Assert.AreEqual(result, expected);
        }
    }
}
