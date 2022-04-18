using Entities.Abstract;

namespace Entities.Concrete
{
    public class Image : IEntity
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
