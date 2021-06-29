using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerDemo.Web.Application.Commands;
using CustomerDemo.Web.Application.Queries;
using CustomerDemo.Web.Data;
using CustomerDemo.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CustomerDemo.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeController : ControllerBase{
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _dbContext;

        public EmployeeController(ILogger<EmployeeController> logger,IMediator mediator ,ApplicationDbContext dbContext){
            this._logger = logger;
            this._mediator = mediator;
            this._dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAsync(){
            var result = await _mediator.Send(new GetEmployeesQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeAdded>> AddAsync([FromBody]AddEmployeeCommand command){
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
