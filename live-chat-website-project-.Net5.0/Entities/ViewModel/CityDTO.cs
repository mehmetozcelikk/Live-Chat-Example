using Entities.Abstract;

namespace Entities.ViewModel
{
    public class CityDTO : BaseDTO, IDTO
    {
        public int CountryId { get; set; }
        public string Cities { get; set; }
    }
}
