using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataRepository.DataAccess;
using DataRepository.Models;
using DataRepository.Services.DataBaseService;
using NUnit.Framework;
using System.Threading.Tasks;
using StrategyServices.Users;

namespace UnitTests.DataRepositoryTests
{
    [TestFixture]
    class UsersTable
    {
        [Test]
        public void Test1DataBaseCriation()
        {
            int rez = 0;
            var usersService = new UsersService();
            string sessionCode = "abc";
            usersService.AddNewUser("user1", "1111", sessionCode);
            if (usersService.AuthorizedUser("user1", "1111"))
                rez++;
            usersService.DeleteUser("user1", "1111");
            if (!usersService.AuthorizedUser("user1", "1111"))
                rez++;
            Assert.AreEqual(rez, 2);
        }

        [Test]
        public void Test2Registration()
        {
            int rez = 0;
            var usersService = new UsersService();
            string sessionCode;
            if (usersService.Registration("jeka", "12777", out sessionCode) == RegistrationState.Success)
                rez++;
            if (usersService.Registration("andrey", "666", out sessionCode) == RegistrationState.Success)
                rez++;
            if (usersService.Registration("lev22", "cap121", out sessionCode) == RegistrationState.Success)
                rez++;
            if (usersService.Registration("andrey", "555", out sessionCode) == RegistrationState.LoginExist)
                rez++;
            Assert.AreEqual(rez, 4);
        }

        [Test]
        public void Test3Authorization()
        {
            int rez = 0;
            var usersService = new UsersService();
            string sessionCode;
            if (usersService.Authorization("jeka", "12777", out sessionCode) == AuthorizationState.Success)
                rez++;
            if (usersService.Authorization("lev22", "cap121", out sessionCode) == AuthorizationState.Success)
                rez++;
            if (usersService.Authorization("lev23", "cap121", out sessionCode) == AuthorizationState.WrongLoginOrPassword)
                rez++;
            if (usersService.Authorization("lev22", "5800", out sessionCode) == AuthorizationState.WrongLoginOrPassword)
                rez++;
            if (rez == 4)
            {
                usersService.DeleteUser("jeka", "12777");
                if (!usersService.AuthorizedUser("jeka", "12777"))
                    rez++;
                usersService.DeleteUser("andrey", "666");
                if (!usersService.AuthorizedUser("andrey", "666"))
                    rez++;
                usersService.DeleteUser("lev22", "cap121");
                if (!usersService.AuthorizedUser("lev22", "cap121"))
                    rez++;
            }
            Assert.AreEqual(rez, 7);
        }
    }
}
