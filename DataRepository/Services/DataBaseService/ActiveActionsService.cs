using System.Collections.Generic;
using System.Linq;
using DataRepository.Models;
using DataRepository.Models.GenericRepository;

namespace DataRepository.Services.DataBaseService
{
    public class ActiveActionsService
    {
        public ActiveActionAddedState AddActiveAction(ActiveAction newActiveAction)
        {
            using (var repoUnit = new RepoUnit())
            {
                repoUnit.ActiveActions.Save(newActiveAction);
            }
            return ActiveActionAddedState.Success;
        }

        public void DeleteActiveAction(int activeActionId)
        {
            using (var repoUnit = new RepoUnit())
            {
                var activeAction = repoUnit.ActiveActions.FindFirstBy(aa => aa.Id == activeActionId);
                if (activeAction != null)
                {
                    repoUnit.ActiveActions.Delete(activeAction);
                }
            }
        }

        public List<ActiveAction> GetActiveActions(int activeBusinessId)
        {
            var activeActions = new List<ActiveAction>();
            using (var repoUnit = new RepoUnit())
            {
                activeActions = repoUnit.ActiveBusinesses.FindFirstBy(ab => ab.Id == activeBusinessId).ActiveActions.ToList();
            }
            activeActions.ForEach(aa =>
            {
                aa.Action = null;
                aa.ActiveBusiness = null;
            });
            return activeActions;
        }

        public List<Action> GetActions(int activeBusinessId)
        {
            var activeActions = new List<ActiveAction>();
            var actions = new List<Action>();
            var languagesService = new LanguagesService();
            var langCount = languagesService.GetLanguagesCount();
            using (var repoUnit = new RepoUnit())
            {
                activeActions = repoUnit.ActiveBusinesses.FindFirstBy(ab => ab.Id == activeBusinessId).ActiveActions.ToList();
                activeActions.ForEach(aa => actions.Add(repoUnit.Actions.FindFirstBy(a => a.Id == aa.ActionId)));
            }
            var retActions = new List<Action>();
            foreach (var a in actions)
            {
                if (a.Descriptions != null)
                {
                    if (a.DescriptionsList.Count == langCount)
                    {
                        a.Business = null;
                        retActions.Add(a);
                    }
                }
            }
            return retActions;
        }
    }
}
