using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;

namespace StrategyServices.Businesses
{
    [ServiceContract]
    public interface IBusinessService
    {
        [OperationContract] // Делегируемый метод.
        List<Business> GetBusinesses(Language lang, int regionId);

    }
}
