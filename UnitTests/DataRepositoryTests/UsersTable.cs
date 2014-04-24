using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataRepository.DataAccess;
using DataRepository.Models;
using DataRepository.Services;
using NUnit.Framework;
using System.Threading.Tasks;

namespace UnitTests.DataRepositoryTests
{
    [TestFixture]
    class UsersTable
    {
        [Test]
        public void FirstTest()
        {
            int x = 100;
            Assert.AreEqual(100, x);
        }


        [Test]
        public void DataBaseCriationTest()
        {
            int rez = 0;
            var dataBaseServise = new DataBaseService(true);
            string sessionCode = "abc";
            dataBaseServise.AddNewUser("jeka", "lev22", sessionCode);
            if (dataBaseServise.AuthorizedUser("jeka", "lev22"))
                rez++;
            dataBaseServise.DeleteUser("jeka", "lev22");
            if (!dataBaseServise.AuthorizedUser("jeka", "lev22"))
                rez++;
            Assert.AreEqual(rez, 2);
        }

        [Test]
        public void RegistrationTest()
        {
            var dataBaseServise = new DataBaseService();
            string sessionCode;
            RegistrationState regRez = dataBaseServise.Registration("jeka", "lev22", out sessionCode);
            RegistrationState mustBe = RegistrationState.Success;
            Assert.AreEqual(regRez, mustBe);
        }
    }
}
