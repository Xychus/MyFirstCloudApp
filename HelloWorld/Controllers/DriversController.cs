using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriversController : ControllerBase
    {
        private readonly ILogger<DriversController> _logger;
        private readonly ApiDbContext _context;
        public DriversController(ILogger<DriversController> logger, ApiDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetAllDrivers")]
        public async Task<IActionResult> Get()
        {
            var driver = new Driver()
            {
                DriveNumber = 44,
                Name = "Jean Valjean"
            };

            _context.Add(driver);
            await _context.SaveChangesAsync();

            var allDrivers = _context.Drives.ToListAsync();

            return Ok(allDrivers);
        }
    }
}
