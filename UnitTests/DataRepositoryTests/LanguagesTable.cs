using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using DataRepository.Services.DataBaseService;
using NUnit.Framework;

namespace UnitTests.DataRepositoryTests
{
    [TestFixture]
    class LanguagesTable
    {
        [Test]
        public void Test1GetLanguages()
        {
            int rez = 0;
            var languagesService = new LanguagesService();
            var languages = languagesService.GetLanguages();
            if (languages[0] == "English" && languages[1] == "Russian")
                rez++;
            var langCount = languagesService.GetLanguagesCount();
            if (langCount == languages.Count)
                rez++;
            Assert.AreEqual(rez, 2);
        }

        [Test]
        public void Test2GetAddEditandDeleteLanguages()
        {
            int rez = 0;
            var languagesService = new LanguagesService();
            var newLanguages = new List<Language>
            {
                new Language{LanguageName = "Ukrainian"},
                new Language{LanguageName = "German"}
            };
            var languages = languagesService.GetLanguagesList();
            if (languages.Count == 2)
                rez++;
            languagesService.AddLanguages(newLanguages);
            languages = languagesService.GetLanguagesList();
            if (languages.Count == 4)
                rez++;
            if (languages[2].LanguageName == "Ukrainian" && languages[3].LanguageName == "German")
                rez++;
            languages[3].LanguageName = "Deutsch";
            languagesService.EditLanguages(languages);
            languages = languagesService.GetLanguagesList();
            if (languages.Count == 4)
                rez++;
            if (languages[2].LanguageName == "Ukrainian" && languages[3].LanguageName == "Deutsch")
                rez++;
            languagesService.DeleteLanguages(new List<int> { languages[2].Id, languages[3].Id });
            languages = languagesService.GetLanguagesList();
            if (languages.Count == 2)
                rez++;
            if (languages[0].LanguageName == "English" && languages[1].LanguageName == "Russian")
                rez++;
            Assert.AreEqual(rez, 7);
        }
    }
}
