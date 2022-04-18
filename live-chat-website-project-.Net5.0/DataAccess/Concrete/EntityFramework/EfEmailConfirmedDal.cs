using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEmailConfirmedDal : EfEntityRepositoryBase<EmailConfirmed, DataContext>, IEmailConfirmedDal
    {
    }
}
