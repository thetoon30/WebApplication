using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Services.Abstract;
using WebApplication.Services.Models;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;
        public ManufacturersController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        // GET api/manufacturers
        //todo: create a method to return all manufacturers and number of models for these manufacturers
        [HttpGet]
        public ActionResult<IEnumerable<ManufacturerModel>> Get()
        {
            var output = _manufacturerService.GetManufacturers();

            return output;
        }

        // GET api/manufacturers/modelname/488GTB
        //todo: Create a method to get manufacturer name by model
        [HttpGet("modelName/{modelName}")]
        public ActionResult<string> Get(string modelName)
        {
            var output = _manufacturerService.GetManufacturerByModel(modelName);

            return output == null ? "Not Found" : output;
        }
    }
}