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

        public List<Language> GetLanguagesList()
        {
            var allLanguages = new List<Language>();
            using (var repoUnit = new RepoUnit())
            {
                allLanguages.AddRange(repoUnit.Languages.Load());
            }
            allLanguages.ForEach(l =>
            {
                if (l.LanguageName == null)
                    l.LanguageName = "";
            });
            return allLanguages;
        }

        public void AddLanguages(List<Language> newLanguages)
        {
            using (var repoUnit = new RepoUnit())
            {
                foreach (var l in newLanguages)
                {
                    repoUnit.Languages.Save(l);
                }
            }
        }

        public void EditLanguages(List<Language> languages)
        {
            using (var repoUnit = new RepoUnit())
            {
                foreach (var l in languages)
                {
                    repoUnit.Languages.Edit(l);
                }
            }
        }

        public void DeleteLanguages(List<int> languageIds)
        {
            using (var repoUnit = new RepoUnit())
            {
                foreach (var id in languageIds)
                {
                    var language = repoUnit.Languages.FindFirstBy(l => l.Id == id);
                    if (language != null)
                    {
                        repoUnit.Languages.Delete(language);
                    }
                }
            }
        }

    }
}
