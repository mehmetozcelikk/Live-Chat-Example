using Entities.Abstract;
using System;

namespace Entities.ViewModel
{
    public class ApplicationUserDTO : BaseDTO, IDTO
    {
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Token { get; set; }


    }
}
