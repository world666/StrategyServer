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
        public void TestGetBusinesses()
        {
            int rez = 0;
            var businessesService = new BusinessesService();
            var businesses = businessesService.GetBusinesses(Language.Russian, 1);
            if (businesses[0].BusinessesNames == "Завод" && businesses[1].BusinessesNames == "Шахта")
                rez++;
            if (businesses[0].BusinessesNamesList[0] == "Завод" && businesses[1].BusinessesNamesList[0] == "Шахта")
                rez++;
            if (businesses[0].Descriptions == "Металлургический завод" && businesses[1].Descriptions == "Угольная шахта")
                rez++;
            if (businesses[0].RegionId == 1 && businesses[1].RegionId == 1)
                rez++;
            businesses = businessesService.GetBusinesses(Language.Russian, 3);
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
    }
}
