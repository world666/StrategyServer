using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;

namespace StrategyServices.ActiveBusinesses
{
    [ServiceContract]
    public interface IActiveBusinessService
    {
        [OperationContract]
        ActiveBusinessAddedState AddBusiness(ActiveBusinessData newActiveBusiness);

        [OperationContract]
        void DeleteBusiness(int activeBusinessId);

        [OperationContract]
        List<ActiveBusinessData> GetActiveBusinesses(int userId);

        [OperationContract]
        List<BusinessData> GetBusinesses(int userId);
    }

    [DataContract]
    public class ActiveBusinessData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public int BusinessId { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime LastUpdate { get; set; }

        [DataMember]
        public bool LeasePurchase { get; set; }
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
