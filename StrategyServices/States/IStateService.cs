using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;

namespace StrategyServices.States
{
    [ServiceContract]
    public interface IStateService
    {
        [OperationContract(Name = "GetStatesByLanguage")] // Делегируемый метод.
        List<StateData> GetStates(Language lang);

        [OperationContract(Name = "GetStates")]
        List<StateData> GetStates();

        [OperationContract]
        void AddStates(List<StateData> statesList);

        [OperationContract]
        void EditStates(List<StateData> statesList);

        [OperationContract]
        void DeleteStates(List<int> stateIds);
    }

    [DataContract]
    public class StateData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string StatesNames { get; set; }

        [DataMember]
        public List<string> StatesNamesList { get; set; }

        [DataMember]
        public double CountryDevelopmentCoef { get; set; }

        [DataMember]
        public double CountryCurrencyUnit { get; set; }

        [DataMember]
        public double NewsInfluenceCoef { get; set; }

        [DataMember]
        public double LicensesExcises { get; set; }
    }
}
