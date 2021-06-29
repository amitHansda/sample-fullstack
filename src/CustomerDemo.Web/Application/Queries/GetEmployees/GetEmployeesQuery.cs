using System.Collections.Generic;
using MediatR;

namespace CustomerDemo.Web.Application.Queries
{
    public class GetEmployeesQuery : IRequest<List<EmployeeModel>>
    {

    }
}