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
        public List<State> GetStates(Language lang)
        {
            var language = Convert.ToInt32(lang);
            var allstates = new List<State>();
            var langCount = Enum.GetNames(typeof (Language)).Length;
            int i = 0;
            using (var repoUnit = new RepoUnit())
            {
                allstates.AddRange(repoUnit.States.Load());
            }
            allstates.ForEach(st =>
            {
                if (st.StatesNamesList.Count != langCount)
                {
                    allstates[i] = null;
                }
                else
                {
                    st.StatesNamesList = new List<string>() { st.StatesNamesList[language] };
                    st.Regions = null;
                }
                i++;
            });
            return allstates;
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
