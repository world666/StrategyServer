using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using DataRepository.Services.DataBaseService;
using NUnit.Framework;
using StrategyServices.States;

namespace UnitTests.DataRepositoryTests
{
    [TestFixture]
    class StatesTable
    {

        [Test]
        public void Test1GetStates()
        {
            int rez = 0;
            var statesService = new StatesService();
            var states = statesService.GetStates(1);
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

        [Test]
        public void Test2AddandDeleteStates()
        {
            int rez = 0;
            var statesService = new StatesService();
            var newStates = new List<State>
            {
                new State{StatesNamesList = new List<string> {"Russia", "Россия"}},
                new State{StatesNamesList = new List<string> {"Germany", "Германия"}}
            };
            statesService.AddStates(newStates);
            var states = statesService.GetStates(1);
            if (states[0].StatesNamesList[0] == "Украина" && states[1].StatesNamesList[0] == "Англия" && states[2].StatesNamesList[0] == "Россия" && states[3].StatesNamesList[0] == "Германия")
                rez++;
            if (states.Count == 4)
                rez++;
            statesService.DeleteStates(new List<int> { states[2].Id, states[3].Id });
            states = statesService.GetStates(1);
            if (states.Count == 2)
                rez++;
            if (states[0].StatesNamesList[0] == "Украина" && states[1].StatesNamesList[0] == "Англия")
                rez++;
            Assert.AreEqual(rez, 4);
        }

        [Test]
        public void Test3EditStates()
        {
            int rez = 0;
            var statesService = new StatesService();
            var states = statesService.GetStates();
            if (states[0].LicensesExcises == 0 && states[1].LicensesExcises == 0)
                rez++;
            if (states.Count == 2)
                rez++;
            states[0].LicensesExcises = 1;
            statesService.EditStates(states);
            states = statesService.GetStates();
            if (states.Count == 2)
                rez++;
            if (states[0].LicensesExcises == 1 && states[1].LicensesExcises == 0)
                rez++;
            states[0].LicensesExcises = 0;
            statesService.EditStates(states);
            states = statesService.GetStates();
            if (states[0].LicensesExcises == 0 && states[1].LicensesExcises == 0)
                rez++;
            if (states.Count == 2)
                rez++;
            Assert.AreEqual(rez, 6);
        }

        [Test]
        public void Test4LangExeptionStates()
        {
            int rez = 0;
            var statesService = new StatesService();
            var newStates = new List<State>
            {
                new State{StatesNamesList = new List<string> {"Italy"}},
                new State{StatesNamesList = new List<string> {"Germany", "Германия"}}
            };
            statesService.AddStates(newStates);
            var states = statesService.GetStates(1);
            if (states.Count == 3)
                rez++;
            statesService.DeleteStates(new List<int> {states[2].Id });
            states = statesService.GetStates(1);
            if (states.Count == 2)
                rez++;
            if (states[0].StatesNamesList[0] == "Украина" && states[1].StatesNamesList[0] == "Англия")
                rez++;
            Assert.AreEqual(rez, 3);
        }

    }
}
