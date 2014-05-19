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
    class StatesTable
    {
        [Test]
        public void TestGetStates()
        {
            int rez = 0;
            var statesService = new StatesService();
            var states = statesService.GetStates(Language.Russian);
            if (states[0].StatesNames == "Украина" && states[1].StatesNames == "Англия")
                rez++;
            if (states[0].Id == 1 && states[1].Id == 2)
                rez++;
            if (states[0].StatesNamesList.Count == 1 && states[1].StatesNamesList.Count == 1)
                rez++;
            if (states[0].StatesNamesList[0] == "Украина" && states[1].StatesNamesList[0] == "Англия")
                rez++;
            Assert.AreEqual(rez, 4);
        }
    }
}
