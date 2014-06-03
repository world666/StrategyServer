using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
        List<BusinessData> GetBusinesses(Language lang, int regionId);
        [OperationContract(Name = "GetBusinesses")]
        List<BusinessData> GetBusinesses(int regionId);
        [OperationContract]
        void AddBusinesses(List<BusinessData> businessesList);
        [OperationContract]
        void EditBusinesses(List<BusinessData> businessesList);
        [OperationContract]
        void DeleteBusinesses(List<int> businessIds);
    }

    [DataContract]
    public class BusinessData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string BusinessesNames { get; set; }

        [DataMember]
        public List<string> BusinessesNamesList { get; set; }

        [DataMember]
        public string Descriptions { get; set; }

        [DataMember]
        public List<string> DescriptionsList { get; set; }

        [DataMember]
        public string Addresses { get; set; }

        [DataMember]
        public List<string> AddressesList { get; set; }

        [DataMember]
        public int RegionId { get; set; }
    }
}
