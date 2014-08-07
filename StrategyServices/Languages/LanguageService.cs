using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using DataRepository.Services.DataBaseService;

namespace StrategyServices.Languages
{
    public class LanguageService : ILanguageService
    {
        public LanguageService()
        {
            _languagesService = new LanguagesService();
        }
        public List<string> GetLanguages()
        {
            return _languagesService.GetLanguages();
        }
        public int GetLanguagesCount()
        {
            return _languagesService.GetLanguagesCount();
        }
        public List<LanguageData> GetLanguagesList()
        {
            var languages = _languagesService.GetLanguagesList();
            var retLanguage = languages.Select(l => new LanguageData
            {
                Id = l.Id,
                LanguageName = l.LanguageName
            }).ToList();
            return retLanguage;
        }
        public void AddLanguages(List<LanguageData> newLanguages)
        {
            var languages = newLanguages.Select(l => new Language
            {
                Id = l.Id,
                LanguageName = l.LanguageName
            }).ToList();
            _languagesService.AddLanguages(languages);
        }
        public void EditLanguages(List<LanguageData> languagesList)
        {
            var languages = languagesList.Select(l => new Language
            {
                Id = l.Id,
                LanguageName = l.LanguageName
            }).ToList();
            _languagesService.EditLanguages(languages);
        }
        public void DeleteLanguages(List<int> languageIds)
        {
            _languagesService.DeleteLanguages(languageIds);
        }

        private LanguagesService _languagesService;
    }
}
