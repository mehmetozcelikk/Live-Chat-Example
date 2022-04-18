using Entities.Abstract;
using System;

namespace Entities.ViewModel
{
    public class EmailConfirmedDTO : BaseDTO, IDTO
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string EmailConfirmedCode { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
