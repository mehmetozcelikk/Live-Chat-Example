using Entities.Abstract;

namespace Entities.ViewModel
{
    public class BaseDTO : IDTO
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
