using System.Threading;
using System.Threading.Tasks;
using CustomerDemo.Web.Data;
using CustomerDemo.Web.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CustomerDemo.Web.Application.Commands
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, EmployeeAdded>
    {
        private readonly ILogger<AddEmployeeCommandHandler> _logger;
        private readonly ApplicationDbContext _dbContext;

        public AddEmployeeCommandHandler(ILogger<AddEmployeeCommandHandler> logger, ApplicationDbContext dbContext)
        {
            this._logger = logger;
            this._dbContext = dbContext;
        }
        public async Task<EmployeeAdded> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entry = new Employee{
                Email = request.EmailAddress,
                FirstName = request.FirstName,
                LastName = request.LastName,
                JoiningDate = request.JoiningDate,
                LastWorkingDay = null
            };
            _dbContext.Employees.Add(entry);
            await _dbContext.SaveChangesAsync();
            return new EmployeeAdded{IsSuccess = true, Id = entry.Id};
        }
    }
}