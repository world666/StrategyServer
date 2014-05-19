using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using DataRepository.Services.DataBaseService;

namespace StrategyServices.Regions
{
    public class RegionService : IRegionService
    {
        public RegionService()
        {
            _regionsService = new RegionsService();
        }
        public List<Region> GetRegions(Language lang, int stateId)
        {
            return _regionsService.GetRegions(lang, stateId);
        }

        private RegionsService _regionsService;
    }
}
