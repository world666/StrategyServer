using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Services.DataBaseService;

namespace StrategyServices.Actions
{
    public class ActionService : IActionService
    {
        public ActionService()
        {
            _actionsService = new ActionsService();
        }

        private ActionsService _actionsService;
    }
}
