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
    class ActiveBusinessesTable
    {
        [Test]
        public void Test1AddGetandDeleteActiveBusinesses()
        {
            int rez = 0;
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
            if (activeBusinesses.Count == 2)
                rez++;
            if (activeBusinesses2.Count == 1)
                rez++;
            if (businesses.Count == 2)
                rez++;
            if (businesses[0].BusinessesNamesList[1] == "Завод" && businesses[1].BusinessesNamesList[1] == "Стадион")
                rez++;
            for (int i = 0; i < activeBusinesses.Count; i++)
            {
                activeBusinessesService.DeleteBusiness(activeBusinesses[i].Id);
            }
            activeBusinessesService.DeleteBusiness(activeBusinesses2[0].Id);
            activeBusinesses = activeBusinessesService.GetActiveBusinesses(user1.Id);
            activeBusinesses2 = activeBusinessesService.GetActiveBusinesses(user2.Id);
            if (activeBusinesses.Count == 0 && activeBusinesses2.Count == 0)
                rez++;
            usersService.DeleteUser(user1.Login, "1111");
            usersService.DeleteUser(user2.Login, "2222");
            Assert.AreEqual(rez, 5);
        }
    }
}
