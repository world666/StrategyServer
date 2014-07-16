using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;

namespace StrategyServices.ActiveActions
{
    [ServiceContract]
    public interface IActiveActionService
    {
        [OperationContract]
        ActiveActionAddedState AddActiveAction(ActiveActionData newActiveAction);

        [OperationContract]
        void DeleteActiveAction(int activeActionId);

        [OperationContract]
        List<ActiveActionData> GetActiveActions(int activeBusinessId);

        [OperationContract]
        List<ActionData> GetActions(int activeBusinessId);
    }

    [DataContract]
    public class ActiveActionData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ActionId { get; set; }

        [DataMember]
        public int ActiveBusinessId { get; set; }
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
