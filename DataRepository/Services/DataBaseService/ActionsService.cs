using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models.GenericRepository;
using Action = DataRepository.Models.Action;

namespace DataRepository.Services.DataBaseService
{
    public class ActionsService
    {
        public void AddActions(List<Action> newActions)
        {
            using (var repoUnit = new RepoUnit())
            {
                foreach (var acn in newActions)
                {
                    repoUnit.Actions.Save(acn);
                }
            }
        }

        public void EditActions(List<Action> actions)
        {
            using (var repoUnit = new RepoUnit())
            {
                foreach (var acn in actions)
                {
                    repoUnit.Actions.Edit(acn);
                }
            }
        }

        public void DeleteActions(List<int> actionsIds)
        {
            using (var repoUnit = new RepoUnit())
            {
                foreach (var id in actionsIds)
                {
                    var action = repoUnit.Actions.FindFirstBy(a => a.Id == id);
                    if (action != null)
                    {
                        repoUnit.Actions.Delete(action);
                    }
                }
            }
        }

        public List<Action> GetActions(int languageId, int businessId)
        {
            var actions = new List<Action>();
            var languagesService = new LanguagesService();
            var langCount = languagesService.GetLanguagesCount();
            using (var repoUnit = new RepoUnit())
            {
                actions = repoUnit.Businesses.FindFirstBy(b => b.Id == businessId).Actions.ToList();
            }
            var retActions = new List<Action>();
            foreach (var a in actions)
            {
                if (a.Descriptions != null)
                {
                    if (a.DescriptionsList.Count == langCount)
                    {
                        a.DescriptionsList = new List<string>() { a.DescriptionsList[languageId] };
                        a.Business = null;
                        retActions.Add(a);
                    }
                }
            }
            return retActions;
        }

        public List<Action> GetActions(int businessId)
        {
            var actions = new List<Action>();
            using (var repoUnit = new RepoUnit())
            {
                actions = repoUnit.Businesses.FindFirstBy(b => b.Id == businessId).Actions.ToList();
            }
            actions.ForEach(a =>
            {
                if (a.Descriptions == null)
                    a.Descriptions = "";
                a.Business = null;
            });
            return actions;
        }
    }
}
