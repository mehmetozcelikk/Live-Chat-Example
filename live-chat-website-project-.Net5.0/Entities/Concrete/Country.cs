using Entities.Abstract;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Country : IEntity
    {
        public int Id { get; set; }
        public string Countries { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
