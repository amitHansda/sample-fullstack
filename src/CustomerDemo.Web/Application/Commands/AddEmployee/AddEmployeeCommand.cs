using System;
using MediatR;

namespace CustomerDemo.Web.Application.Commands
{
    public class AddEmployeeCommand : IRequest<EmployeeAdded>{
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string EmailAddress{get;set;}
        public DateTime JoiningDate{get;set;}
    }
}