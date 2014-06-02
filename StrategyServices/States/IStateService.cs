using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;

namespace StrategyServices.States
{
    [ServiceContract]
    public interface IStateService
    {
        [OperationContract] // Делегируемый метод.
        List<State> GetStates(Language lang);

        [OperationContract]
        List<State> GetStates();

        [OperationContract]
        void AddStates(List<State> newStates);

        [OperationContract]
        void EditStates(List<State> states);

        [OperationContract]
        void DeleteStates(List<int> stateIds);
    }
}
