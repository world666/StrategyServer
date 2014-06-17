using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using DataRepository.Models.GenericRepository;

namespace DataRepository.Services.DataBaseService
{
    public class StatesService
    {
        public List<State> GetStates(int languageId)
        {
            var allstates = new List<State>();
            var languagesService = new LanguagesService();
            var langCount = languagesService.GetLanguagesCount();
            int i = 0;
            using (var repoUnit = new RepoUnit())
            {
                allstates.AddRange(repoUnit.States.Load());
            }
            var retStates = new List<State>();
            foreach (var st in allstates)
            {
                if (st.StatesNamesList.Count == langCount && st.StatesNames != null)
                {
                    st.StatesNamesList = new List<string>() { st.StatesNamesList[languageId] };
                    st.Regions = null;
                    retStates.Add(st);
                }
            }
            return retStates;
        }

        public List<State> GetStates()
        {
            var allstates = new List<State>();
            using (var repoUnit = new RepoUnit())
            {
                allstates.AddRange(repoUnit.States.Load());
            }
            allstates.ForEach(st =>
            {
                if (st.StatesNames == null)
                    st.StatesNames = "";
                st.Regions = null;
            });
            return allstates;
        }

        public void AddStates(List<State> newStates)
        {
            using (var repoUnit = new RepoUnit())
            {
                foreach (var st in newStates)
                {
                    repoUnit.States.Save(st);
                }
            }
        }

        public void EditStates(List<State> states)
        {
            using (var repoUnit = new RepoUnit())
            {
                foreach (var st in states)
                {
                    repoUnit.States.Edit(st);
                }
            }
        }

        public void DeleteStates(List<int> stateIds)
        {
            using (var repoUnit = new RepoUnit())
            {
                foreach (var id in stateIds)
                {
                    var state = repoUnit.States.FindFirstBy(s => s.Id == id);
                    if (state != null)
                    {
                        repoUnit.States.Delete(state);
                    } 
                }
            }
        }

    }
}
