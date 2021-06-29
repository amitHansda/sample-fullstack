using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerDemo.Web.Models;
using Microsoft.Extensions.Logging;

namespace CustomerDemo.Web.Data
{
    public class SeedService : ISeedService
    {
        private readonly ILogger<SeedService> _logger;
        private readonly ApplicationDbContext _dbContext;

        public SeedService(ILogger<SeedService> logger,ApplicationDbContext dbContext)
        {
            this._logger = logger;
            this._dbContext = dbContext ?? throw new System.ArgumentNullException(nameof(dbContext));
        }


        public async Task<bool> RunDepartmentSeedAsync()
        {
           var departments = new List<Department>{
               new Department{ Name = "HR", Code = "HR"},
               new Department{ Name = "Admin",Code = "ADMIN"},
               new Department{ Name = "IT and Infrastructure", Code = "ITN"},
               new Department{ Name = "Services", Code = "SERVICES"}
           };

           foreach (var item in departments)
           {
               var existing = _dbContext.Departments.FirstOrDefault(x=>x.Code == item.Code);
               if(existing==null){
                   _dbContext.Departments.Add(item);
                   await _dbContext.SaveChangesAsync();
               }else{
                   existing.Name = item.Name;
                   _dbContext.Departments.Update(existing);
                   await _dbContext.SaveChangesAsync();
               }
           }
            _logger.LogInformation("Ran department seed...");
           return true;
        }
    }

}
