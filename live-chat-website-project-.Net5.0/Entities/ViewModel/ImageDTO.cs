using Entities.Abstract;

namespace Entities.ViewModel
{
    public class ImageDTO : BaseDTO, IDTO
    {
        public int? PostingId { get; set; }
        public string ImagePath { get; set; }
    }
}
