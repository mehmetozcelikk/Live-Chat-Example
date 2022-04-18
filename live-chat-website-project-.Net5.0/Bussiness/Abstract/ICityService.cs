using Entities.ViewModel;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICityService
    {
        ResultDTO<List<CityDTO>> GetAllByCountryId(int id);
    }
}