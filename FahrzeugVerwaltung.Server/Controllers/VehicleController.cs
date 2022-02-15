using FahrzeugVerwaltung.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FahrzeugVerwaltung.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        

        private readonly ILogger<VehicleController> _logger;

        public VehicleController(ILogger<VehicleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            return Enumerable.Empty<Vehicle>();
        }
    }
}
