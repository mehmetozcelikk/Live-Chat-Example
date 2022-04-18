using Entities.Abstract;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class City : IEntity
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string CityName { get; set; }
        public Country Country { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
