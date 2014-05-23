using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using DataRepository.Services.DataBaseService;

namespace StrategyServices.States
{
    public class StateService : IStateService
    {
        public StateService()
        {
            _statesService = new StatesService();
        }
        public List<State> GetStates(Language lang)
        {
            return _statesService.GetStates(lang);
        }
        public void AddStates(List<State> newStates)
        {
            _statesService.AddStates(newStates);
        }
        public void DeleteStates(List<int> stateIds)
        {
            _statesService.DeleteStates(stateIds);
        }
        private StatesService _statesService;
    }
}
