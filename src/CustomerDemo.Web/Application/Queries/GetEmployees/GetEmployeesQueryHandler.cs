using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CustomerDemo.Web.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CustomerDemo.Web.Application.Queries
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, List<EmployeeModel>>
    {
        private readonly ILogger<GetEmployeesQueryHandler> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEmployeesQueryHandler(ILogger<GetEmployeesQueryHandler> logger,ApplicationDbContext dbContext,IMapper mapper)
        {
            this._logger = logger;
            this._dbContext = dbContext;
            this._mapper = mapper;
        }
        public async Task<List<EmployeeModel>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<List<EmployeeModel>>(await _dbContext.Employees.ToListAsync());
            return result;
        }
    }
}