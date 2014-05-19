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
            using (var repoUnit = new RepoUnit())
            {
                allstates.AddRange(repoUnit.States.Load());
            }
            return allstates.Select(st => new State()
            {
                Id = st.Id,
                StatesNamesList = new List<string>() { st.StatesNamesList[language] }
            }).ToList();
        }
    }
}
