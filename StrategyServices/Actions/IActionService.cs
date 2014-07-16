using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StrategyServices.Actions
{
    [ServiceContract]
    public interface IActionService
    {
        [OperationContract(Name = "GetActionsByLanguage")]
        List<ActionData> GetActions(int languageId, int businessId);
        [OperationContract(Name = "GetActions")]
        List<ActionData> GetActions(int businessId);
        [OperationContract]
        void AddActions(List<ActionData> newActions);
        [OperationContract]
        void EditActions(List<ActionData> actions);
        [OperationContract]
        void DeleteActions(List<int> actionsIds);
    }

    [DataContract]
    public class ActionData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Descriptions { get; set; }

        [DataMember]
        public List<string> DescriptionsList { get; set; }

        [DataMember]
        public int? BusinessId { get; set; }
    }
}
