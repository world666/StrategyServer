using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using DataRepository.Services;
using DataRepository.Services.DataBaseService;
using NUnit.Framework;
using Action = DataRepository.Models.Action;

namespace UnitTests.DataRepositoryTests
{
    [TestFixture]
    class ActiveActionsTable
    {
        [Test]
        public void Test1AddGetandDeleteActiveActions()
        {
            int rez = 0;
            var activeActionsService = new ActiveActionsService();
            var activeBusinessesService = new ActiveBusinessesService();
            var usersService = new UsersService();
            string sessionCode = "abc";
            usersService.AddNewUser("user1", "1111", sessionCode);
            usersService.AddNewUser("user2", "2222", sessionCode);
            var user1 = usersService.GetUser("user1");
            var user2 = usersService.GetUser("user2");
            var newActiveBusinesses = new List<ActiveBusiness>
            {
                new ActiveBusiness{UserId = user1.Id, BusinessId = 1, LeasePurchase = true},
                new ActiveBusiness{UserId = user2.Id, BusinessId = 2, LeasePurchase = true},
                new ActiveBusiness{UserId = user1.Id, BusinessId = 3, LeasePurchase = true},
            };
            for (int i = 0; i < newActiveBusinesses.Count; i++)
            {
                activeBusinessesService.AddBusiness(newActiveBusinesses[i]);
            }
            var activeBusinesses = activeBusinessesService.GetActiveBusinesses(user1.Id);
            var activeBusinesses2 = activeBusinessesService.GetActiveBusinesses(user2.Id);
            var businesses = activeBusinessesService.GetBusinesses(user1.Id);
            var actionsService = new ActionsService();
            var newActions = new List<Action>
            {
                new Action{DescriptionsList = new List<string> {"Advertising campaign", "Рекламная кампания"},
                    BusinessId = 2},
                new Action{DescriptionsList = new List<string> {"Temporary discounts", "Временные скидки"},
                    BusinessId = 3},
                new Action{DescriptionsList = new List<string> {"Fictitious discounts", "Фиктивные скидки"},
                    BusinessId = 2}
            };
            actionsService.AddActions(newActions);
            var allactions = actionsService.GetActions(2);
            var allactions2 = actionsService.GetActions(3);
            var newActiveActions = new List<ActiveAction>
            {
                new ActiveAction{ActionId = allactions[0].Id, ActiveBusinessId = activeBusinesses[0].Id},
                new ActiveAction{ActionId = allactions2[0].Id, ActiveBusinessId = activeBusinesses[1].Id},
                new ActiveAction{ActionId = allactions[1].Id, ActiveBusinessId = activeBusinesses[1].Id}
            };
            for (int i = 0; i < newActiveActions.Count; i++)
            {
                activeActionsService.AddActiveAction(newActiveActions[i]);
            }
            var activeActions = activeActionsService.GetActiveActions(activeBusinesses[0].Id);
            var activeActions2 = activeActionsService.GetActiveActions(activeBusinesses[1].Id);
            var actions = activeActionsService.GetActions(activeBusinesses[0].Id);
            var actions2 = activeActionsService.GetActions(activeBusinesses[1].Id);
            if (activeActions.Count == 1 && activeActions2.Count == 2 && actions.Count == 1 && actions2.Count == 2)
                rez++;
            if (activeActions2[0].ActionId == allactions2[0].Id && activeActions2[1].ActionId == allactions[1].Id)
                rez++;
            if (actions2[0].DescriptionsList[1] == "Временные скидки" && actions2[1].DescriptionsList[1] == "Фиктивные скидки")
                rez++;
            for (int i = 0; i < activeActions2.Count; i++)
            {
                activeActionsService.DeleteActiveAction(activeActions2[i].Id);
            }
            activeActionsService.DeleteActiveAction(activeActions[0].Id);
            activeActions = activeActionsService.GetActiveActions(activeBusinesses[0].Id);
            activeActions2 = activeActionsService.GetActiveActions(activeBusinesses[1].Id);
            actions = activeActionsService.GetActions(activeBusinesses[0].Id);
            actions2 = activeActionsService.GetActions(activeBusinesses[1].Id);
            if (activeActions.Count == 0 && activeActions2.Count == 0 && actions.Count == 0 && actions2.Count == 0)
                rez++;
            for (int i = 0; i < activeBusinesses.Count; i++)
            {
                activeBusinessesService.DeleteBusiness(activeBusinesses[i].Id);
            }
            activeBusinessesService.DeleteBusiness(activeBusinesses2[0].Id);
            actionsService.DeleteActions(new List<int> { allactions[0].Id, allactions[1].Id, allactions2[0].Id });
            usersService.DeleteUser(user1.Login, "1111");
            usersService.DeleteUser(user2.Login, "2222");
            Assert.AreEqual(rez, 4);
        }
    }
}
