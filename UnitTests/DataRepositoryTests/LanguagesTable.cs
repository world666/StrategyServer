using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
