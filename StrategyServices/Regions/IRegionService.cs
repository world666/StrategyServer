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
        [OperationContract] // Делегируемый метод.
        List<Region> GetRegions(Language lang, int stateId);

    }
}
