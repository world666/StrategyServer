using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using DataRepository.Models.GenericRepository;

namespace DataRepository.Services.DataBaseService
{
    public class LanguagesService
    {
        public List<string> GetLanguages()
        {
            var languages = new List<Language>();
            var languagesNames = new List<string>();
            using (var repoUnit = new RepoUnit())
            {
                languages.AddRange(repoUnit.Languages.Load());
            }
            languages.ForEach(l => languagesNames.Add(l.LanguageName));
            return languagesNames;
        }

        public int GetLanguagesCount()
        {
            var languages = new List<Language>();
            using (var repoUnit = new RepoUnit())
            {
                languages.AddRange(repoUnit.Languages.Load());
            }
            return languages.Count;
        }
    }
}
