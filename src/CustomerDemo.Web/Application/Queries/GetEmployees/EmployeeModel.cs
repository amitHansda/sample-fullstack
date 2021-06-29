using System;

namespace CustomerDemo.Web.Application.Queries
{
    public class EmployeeModel{
        public int Id{get;set;}
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string EmailAddress{get;set;}
        public DateTime JoiningDate{get;set;}
        public DateTime LastWorkingDay{get;set;}
    } 
}