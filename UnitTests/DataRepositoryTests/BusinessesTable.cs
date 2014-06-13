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
    class BusinessesTable
    {
        [Test]
        public void Test1GetBusinesses()
        {
            int rez = 0;
            var businessesService = new BusinessesService();
            var businesses = businessesService.GetBusinesses(1, 1);
            if (businesses[0].BusinessesNames == "Завод" && businesses[1].BusinessesNames == "Шахта")
                rez++;
            if (businesses[0].BusinessesNamesList[0] == "Завод" && businesses[1].BusinessesNamesList[0] == "Шахта")
                rez++;
            if (businesses[0].Descriptions == "Металлургический завод" && businesses[1].Descriptions == "Угольная шахта")
                rez++;
            if (businesses[0].RegionId == 1 && businesses[1].RegionId == 1)
                rez++;
            businesses = businessesService.GetBusinesses(1, 3);
            if (businesses[0].BusinessesNames == "Ресторан" && businesses[1].BusinessesNames == "Торговый центр")
                rez++;
            if (businesses[0].BusinessesNamesList[0] == "Ресторан" && businesses[1].BusinessesNamesList[0] == "Торговый центр")
                rez++;
            if (businesses[0].Descriptions == "Итальянская кухня" && businesses[1].Descriptions == "Крупнейший торговый центр Лондона")
                rez++;
            if (businesses[0].RegionId == 3 && businesses[1].RegionId == 3)
                rez++;
            Assert.AreEqual(rez, 8);
        }

        [Test]
        public void Test2AddandDeleteBusinesses()
        {
            int rez = 0;
            var businessesService = new BusinessesService();
            var newBusinesses = new List<Business>
            {
                new Business{BusinessesNamesList = new List<string> {"The Nickel Plant", "Никелевый завод"}, 
                    DescriptionsList = new List<string> {"Largest nickel plant in Ukraine", "Крупнейший никелевый завод Украины"},
                    RegionId = 2},
                    new Business{BusinessesNamesList = new List<string> {"New Plant", "Новый завод"}, 
                    DescriptionsList = new List<string> {"Largest nickel plant in Ukraine", "Крупнейший никелевый завод Украины"},
                    AddressesList = new List<string> {"Artema 81", "Артема 81"},
                    RegionId = 2},
            };
            businessesService.AddBusinesses(newBusinesses);
            var businesses = businessesService.GetBusinesses(1, 2);
            if (businesses.Count == 3)
                rez++;
            if (businesses[0].BusinessesNamesList[0] == "Стадион" && businesses[1] == null && businesses[2].BusinessesNamesList[0] == "Новый завод")
                rez++;
            businessesService.DeleteBusinesses(new List<int> { businesses[2].Id });
            businesses = businessesService.GetBusinesses(1, 2);
            if (businesses.Count == 2)
                rez++;
            if (businesses[0].BusinessesNamesList[0] == "Стадион")
                rez++;
            if (businesses[0].Descriptions == "Олимпийский стадион")
                rez++;
            Assert.AreEqual(rez, 5);
        }

    }
}
