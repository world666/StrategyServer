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

        private StatesService _statesService;
    }
}
