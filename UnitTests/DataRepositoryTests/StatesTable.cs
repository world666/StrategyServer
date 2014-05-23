﻿using System;
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
        public void Test1GetStates()
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
            var states = statesService.GetStates(Language.Russian);
            if (states[0].StatesNamesList[0] == "Украина" && states[1].StatesNamesList[0] == "Англия" && states[2].StatesNamesList[0] == "Россия" && states[3].StatesNamesList[0] == "Германия")
                rez++;
            if (states.Count == 4)
                rez++;
            statesService.DeleteStates(new List<int> { states[2].Id, states[3].Id });
            states = statesService.GetStates(Language.Russian);
            if (states.Count == 2)
                rez++;
            if (states[0].StatesNamesList[0] == "Украина" && states[1].StatesNamesList[0] == "Англия")
                rez++;
            Assert.AreEqual(rez, 4);
        }

    }
}