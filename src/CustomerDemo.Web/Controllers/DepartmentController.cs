using System.Linq;
using System.Threading.Tasks;
using CustomerDemo.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CustomerDemo.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DepartmentController : ControllerBase{
        private readonly ILogger<DepartmentController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public DepartmentController(ILogger<DepartmentController> logger,ApplicationDbContext dbContext)
        {
            this._logger = logger;
            this._dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(){
            var departments = await _dbContext.Departments.Select(x=>x).ToListAsync();
            return Ok(departments);
        }
    }
}
