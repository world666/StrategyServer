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
    class RegionsTable
    {
        [Test]
        public void TestGetregions()
        {
            int rez = 0;
            var regionsService = new RegionsService();
            var regions = regionsService.GetRegions(Language.Russian, 1);
            if (regions[0].RegionsNames == "Донецк" && regions[1].RegionsNames == "Киев")
                rez++;
            if (regions[0].StateId == 1 && regions[1].StateId == 1)
                rez++;
            if (regions[0].RegionsNamesList.Count == 1 && regions[1].RegionsNamesList.Count == 1)
                rez++;
            if (regions[0].RegionsNamesList[0] == "Донецк" && regions[1].RegionsNamesList[0] == "Киев")
                rez++;
            regions = regionsService.GetRegions(Language.English, 2);
            if (regions.Count == 1)
                rez++;
            if (regions[0].RegionsNames == "London")
                rez++;
            if (regions[0].RegionsNamesList[0] == "London")
                rez++;
            if (regions[0].StateId == 2)
                rez++;
            Assert.AreEqual(rez, 8);
        }
    }
}
