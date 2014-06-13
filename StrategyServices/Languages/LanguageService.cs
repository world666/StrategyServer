using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Services.DataBaseService;

namespace StrategyServices.Languages
{
    public class LanguageService : ILanguageService
    {
        public LanguageService()
        {
            _languagessService = new LanguagesService();
        }
        public List<string> GetLanguages()
        {
            return _languagessService.GetLanguages();
        }
        public int GetLanguagesCount()
        {
            return _languagessService.GetLanguagesCount();
        }

        private LanguagesService _languagessService;
    }
}
