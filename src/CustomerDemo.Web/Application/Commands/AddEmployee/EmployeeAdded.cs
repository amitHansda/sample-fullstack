namespace CustomerDemo.Web.Application.Commands
{
    public record EmployeeAdded{
        public bool IsSuccess{get;set;}
        public int? Id{get;set;}
    }
}