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
        public void Test1Getregions()
        {
            int rez = 0;
            var regionsService = new RegionsService();
            var regions = regionsService.GetRegions(1, 1);
            if (regions[0].RegionsNames == "Донецк" && regions[1].RegionsNames == "Киев")
                rez++;
            if (regions[0].StateId == 1 && regions[1].StateId == 1)
                rez++;
            if (regions[0].RegionsNamesList.Count == 1 && regions[1].RegionsNamesList.Count == 1)
                rez++;
            if (regions[0].RegionsNamesList[0] == "Донецк" && regions[1].RegionsNamesList[0] == "Киев")
                rez++;
            regions = regionsService.GetRegions(0, 2);
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

        [Test]
        public void Test2AddandDeleteRegions()
        {
            int rez = 0;
            var regionsService = new RegionsService();
            var newRegions = new List<Region>
            {
                new Region{RegionsNamesList = new List<string> {"Kharkov", "Харьков"}, StateId = 1},
                new Region{RegionsNamesList = new List<string> {"Lvov", "Львов"}, StateId = 1},
            };
            regionsService.AddRegions(newRegions);
            var regions = regionsService.GetRegions(1, 1);
            if (regions.Count == 4)
                rez++;
            if (regions[0].RegionsNamesList[0] == "Донецк" && regions[1].RegionsNamesList[0] == "Киев" && regions[2].RegionsNamesList[0] == "Харьков" && regions[3].RegionsNamesList[0] == "Львов")
                rez++;
            regionsService.DeleteRegions(new List<int> { regions[2].Id, regions[3].Id });
            regions = regionsService.GetRegions(1, 1);
            if (regions.Count == 2)
                rez++;
            if (regions[0].RegionsNamesList[0] == "Донецк" && regions[1].RegionsNamesList[0] == "Киев")
                rez++;
            Assert.AreEqual(rez, 4);
        }
    }
}
