using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Services.DataBaseService;
using NUnit.Framework;
using Action = DataRepository.Models.Action;

namespace UnitTests.DataRepositoryTests
{
    [TestFixture]
    class ActionsTable
    {
        [Test]
        public void Test1AddGetEditandDeleteActions()
        {
            int rez = 0;
            var actionsService = new ActionsService();
            var newActions = new List<Action>
            {
                new Action{DescriptionsList = new List<string> {"Advertising campaign", "Рекламная кампания"},
                    BusinessId = 2},
                new Action{DescriptionsList = new List<string> {"Temporary discounts", "Временные скидки"},
                    BusinessId = 3},
                new Action{DescriptionsList = new List<string> {"Фиктивные скидки"},
                    BusinessId = 2}
            };
            actionsService.AddActions(newActions);
            var actions = actionsService.GetActions(1, 2);
            var allactions = actionsService.GetActions(2);
            var allactions2 = actionsService.GetActions(3);
            if (allactions.Count == 2 && allactions2.Count == 1)
                rez++;
            if (actions.Count == 1)
                rez++;
            if (actions[0].DescriptionsList[0] == "Рекламная кампания")
                rez++;
            allactions[1].DescriptionsList = new List<string> { "Fictitious discounts", "Фиктивные скидки" };
            actionsService.EditActions(allactions);
            actions = actionsService.GetActions(1, 2);
            allactions = actionsService.GetActions(2);
            allactions2 = actionsService.GetActions(3);
            if (allactions.Count == 2 && allactions2.Count == 1)
                rez++;
            if (actions.Count == 2)
                rez++;
            if (actions[0].DescriptionsList[0] == "Рекламная кампания" && actions[1].DescriptionsList[0] == "Фиктивные скидки")
                rez++;
            actionsService.DeleteActions(new List<int> { allactions[0].Id, allactions[1].Id, allactions2[0].Id });
            actions = actionsService.GetActions(1, 2);
            allactions = actionsService.GetActions(2);
            allactions2 = actionsService.GetActions(3);
            if (allactions.Count == 0 && allactions2.Count == 0)
                rez++;
            if (actions.Count == 0)
                rez++;
            Assert.AreEqual(rez, 8);
        }
    }
}
