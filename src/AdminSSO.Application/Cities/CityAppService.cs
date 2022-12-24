using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSSO.Cities
{
    public class CityAppService : AdminSSOAppService, ICityAppService
    {
        private ICityRepository _cityRepository;

        public CityAppService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<List<CityDto>> GetList()
        {
            var list = await _cityRepository.GetListAsync();
            return ObjectMapper.Map<List<City>, List<CityDto>>(list).OrderBy(c=>c.DisplayOrder).ToList();
        }
    }
}
