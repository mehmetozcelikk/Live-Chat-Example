using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfApplicationUserDal : EfEntityRepositoryBase<ApplicationUser, DataContext>, IApplicationUserDal
    {
    }
}
