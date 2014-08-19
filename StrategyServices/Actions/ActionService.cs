using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Services.DataBaseService;
using Action = DataRepository.Models.Action;

namespace StrategyServices.Actions
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class ActionService : IActionService
    {
        public ActionService()
        {
            _actionsService = new ActionsService();
        }
        public List<ActionData> GetActions(int languageId, int businessId)
        {
            var actions = _actionsService.GetActions(languageId, businessId);
            var retActions = actions.Select(st => new ActionData
            {
                Id = st.Id,
                Descriptions = st.Descriptions,
                DescriptionsList = st.DescriptionsList,
                BusinessId = st.BusinessId
            }).ToList();
            return retActions;
        }

        public List<ActionData> GetActions(int businessId)
        {
            var actions = _actionsService.GetActions(businessId);
            var retActions = actions.Select(st => new ActionData
            {
                Id = st.Id,
                Descriptions = st.Descriptions,
                DescriptionsList = st.DescriptionsList,
                BusinessId = st.BusinessId
            }).ToList();
            return retActions;
        }

        public void AddActions(List<ActionData> newActions)
        {
            var actions = newActions.Select(st => new Action
            {
                Id = st.Id,
                Descriptions = st.Descriptions,
                BusinessId = st.BusinessId
            }).ToList();
            _actionsService.AddActions(actions);
        }

        public void EditActions(List<ActionData> actions)
        {
            var editActions = actions.Select(st => new Action
            {
                Id = st.Id,
                Descriptions = st.Descriptions,
                BusinessId = st.BusinessId
            }).ToList();
            _actionsService.AddActions(editActions);
        }

        public void DeleteActions(List<int> actionsIds)
        {
            _actionsService.DeleteActions(actionsIds);
        }

        private ActionsService _actionsService;
    }
}
