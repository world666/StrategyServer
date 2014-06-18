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
        public List<RegionData> GetRegions(int languageId, int stateId)
        {
            var regions = _regionsService.GetRegions(languageId, stateId);
            var retRegion = regions.Select(st => new RegionData
            {
                Id = st.Id,
                RegionsNames = st.RegionsNames,
                RegionsNamesList = st.RegionsNamesList,
                StateId = st.StateId,
                ProfitTax = st.ProfitTax,
                GrossProfitTax = st.GrossProfitTax,
                Industry = st.Industry,
                Cx = st.Cx,
                ServicesSector = st.ServicesSector,
                Trade = st.Trade,
                Tourism = st.Tourism
            }).ToList();
            return retRegion;
        }
        public List<RegionData> GetRegions(int stateId)
        {
            var regions = _regionsService.GetRegions(stateId);
            var retRegion = regions.Select(st => new RegionData
            {
                Id = st.Id,
                RegionsNames = st.RegionsNames,
                RegionsNamesList = st.RegionsNamesList,
                StateId = st.StateId,
                ProfitTax = st.ProfitTax,
                GrossProfitTax = st.GrossProfitTax,
                Industry = st.Industry,
                Cx = st.Cx,
                ServicesSector = st.ServicesSector,
                Trade = st.Trade,
                Tourism = st.Tourism
            }).ToList();
            return retRegion;
        }
        public void AddRegions(List<RegionData> regionsList)
        {
            var regions = regionsList.Select(st => new Region
            {
                Id = st.Id,
                RegionsNames = st.RegionsNames,
                StateId = st.StateId,
                ProfitTax = st.ProfitTax,
                GrossProfitTax = st.GrossProfitTax,
                Industry = st.Industry,
                Cx = st.Cx,
                ServicesSector = st.ServicesSector,
                Trade = st.Trade,
                Tourism = st.Tourism
            }).ToList();
            _regionsService.AddRegions(regions);
        }
        public void EditRegions(List<RegionData> regionsList)
        {
            var regions = regionsList.Select(st => new Region
            {
                Id = st.Id,
                RegionsNames = st.RegionsNames,
                StateId = st.StateId,
                ProfitTax = st.ProfitTax,
                GrossProfitTax = st.GrossProfitTax,
                Industry = st.Industry,
                Cx = st.Cx,
                ServicesSector = st.ServicesSector,
                Trade = st.Trade,
                Tourism = st.Tourism
            }).ToList();
            _regionsService.EditRegions(regions);
        }
        public void DeleteRegions(List<int> regionIds)
        {
            _regionsService.DeleteRegions(regionIds);
        }
        private RegionsService _regionsService;
    }
}
