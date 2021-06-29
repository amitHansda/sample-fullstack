using AutoMapper;
using CustomerDemo.Web.Application.Queries;
using CustomerDemo.Web.Models;

namespace CustomerDemo.Web.Application
{
    public class EmployeeProfile : Profile
    {
     public EmployeeProfile()
     {
         CreateMap<Employee,EmployeeModel>()
            .ForMember(m=>m.EmailAddress, opt=> opt.MapFrom(x=>x.Email));
     }   
    }
}