using Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class Message : IEntity
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime When { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
