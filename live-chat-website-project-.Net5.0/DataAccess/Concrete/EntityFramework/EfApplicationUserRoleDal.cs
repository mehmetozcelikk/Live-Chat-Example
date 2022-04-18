using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfApplicationUserRoleDal : EfEntityRepositoryBase<ApplicationUserRole, DataContext>, IApplicationUserRoleDal
    {
    }
}
