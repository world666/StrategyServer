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
        [OperationContract(Name = "GetBusinessesByLanguage")] // Делегируемый метод.
        List<Business> GetBusinesses(Language lang, int regionId);
        [OperationContract(Name = "GetBusinesses")]
        List<Business> GetBusinesses(int regionId);
        [OperationContract]
        void AddBusinesses(List<Business> newBusinesses);
        [OperationContract]
        void EditBusinesses(List<Business> businesses);
        [OperationContract]
        void DeleteBusinesses(List<int> businessIds);
    }
}
