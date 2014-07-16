using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using DataRepository.Services.DataBaseService;

namespace StrategyServices.ActiveActions
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class ActiveActionService : IActiveActionService
    {
        public ActiveActionService()
        {
            _activeActionsService = new ActiveActionsService();
        }

        public ActiveActionAddedState AddActiveAction(ActiveActionData newActiveAction)
        {
            var activeAction = new ActiveAction
            {
                Id = newActiveAction.Id,
                ActionId = newActiveAction.ActionId,
                ActiveBusinessId = newActiveAction.ActiveBusinessId
            };
            var addedState = _activeActionsService.AddActiveAction(activeAction);
            return addedState;
        }

        public void DeleteActiveAction(int activeActionId)
        {
            _activeActionsService.DeleteActiveAction(activeActionId);
        }

        public List<ActiveActionData> GetActiveActions(int activeBusinessId)
        {
            var activeActions = _activeActionsService.GetActiveActions(activeBusinessId);
            var retActiveActions = activeActions.Select(st => new ActiveActionData
            {
                Id = st.Id,
                ActionId = st.ActionId,
                ActiveBusinessId = st.ActiveBusinessId
            }).ToList();
            return retActiveActions;
        }

        public List<ActionData> GetActions(int activeBusinessId)
        {
            var actions = _activeActionsService.GetActions(activeBusinessId);
            var retActions = actions.Select(st => new ActionData
            {
                Id = st.Id,
                Descriptions = st.Descriptions,
                DescriptionsList = st.DescriptionsList,
                BusinessId = st.BusinessId
            }).ToList();
            return retActions;
        }

        private ActiveActionsService _activeActionsService;
    }
}
