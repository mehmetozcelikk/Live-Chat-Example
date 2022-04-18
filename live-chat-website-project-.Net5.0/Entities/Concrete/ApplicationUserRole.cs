using Entities.Abstract;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class ApplicationUserRole : IEntity
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
