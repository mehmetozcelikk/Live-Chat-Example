using Entities.ViewModel;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICountryService
    {
        ResultDTO<List<CountryDTO>> GetList();
    }
}
