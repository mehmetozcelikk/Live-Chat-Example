using Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class ApplicationUser : IEntity
    {
        public int Id { get; set; }
        public int? ApplicationUserRoleId { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool IsActive { get; set; }

        public City City { get; set; }
        public Country Country { get; set; }
        public ApplicationUserRole ApplicationUserRole { get; set; }
        public ICollection<Image> Image { get; set; }
        public ICollection<Message> Message { get; set; }


    }
}
