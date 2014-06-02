using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;

namespace StrategyServices.Regions
{
    [ServiceContract]
    public interface IRegionService
    {
        [OperationContract(Name = "GetRegionsByLanguage")] // Делегируемый метод.
        List<Region> GetRegions(Language lang, int stateId);
        [OperationContract(Name = "GetRegions")]
        List<Region> GetRegions(int stateId);
        [OperationContract]
        void AddRegions(List<Region> newRegions);
        [OperationContract]
        void EditRegions(List<Region> regions);
        [OperationContract]
        void DeleteRegions(List<int> regionIds);

    }
}
