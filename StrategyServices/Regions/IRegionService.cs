using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
        List<RegionData> GetRegions(Language lang, int stateId);
        [OperationContract(Name = "GetRegions")]
        List<RegionData> GetRegions(int stateId);
        [OperationContract]
        void AddRegions(List<RegionData> regionsList);
        [OperationContract]
        void EditRegions(List<RegionData> regionsList);
        [OperationContract]
        void DeleteRegions(List<int> regionIds);

    }

    [DataContract]
    public class RegionData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string RegionsNames { get; set; }

        [DataMember]
        public List<string> RegionsNamesList { get; set; }

        [DataMember]
        public int StateId { get; set; }

        [DataMember]
        public double ProfitTax { get; set; }

        [DataMember]
        public double GrossProfitTax { get; set; }

        [DataMember]
        public double Industry { get; set; }

        [DataMember]
        public double Cx { get; set; }

        [DataMember]
        public double ServicesSector { get; set; }

        [DataMember]
        public double Trade { get; set; }

        [DataMember]
        public double Tourism { get; set; }
    }
}
