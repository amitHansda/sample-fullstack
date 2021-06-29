using System.Threading.Tasks;

namespace CustomerDemo.Web.Data
{
    public interface ISeedService{
        Task<bool> RunDepartmentSeedAsync();
    }

}
