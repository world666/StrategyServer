using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.DataAccess;
using DataRepository.Models;
using DataRepository.Services.DataBaseService;
using NUnit.Framework;

namespace UnitTests.DataRepositoryTests
{
    [TestFixture]
    class VersionsTable
    {
        [Test]
        public void TestVersions()
        {
           // Database.SetInitializer(new ServerDbInitializer());
            int rez = 0;
            var versionsService = new VersionsService();
            if (versionsService.VerifyUserAppVersion("v1.0") == VersionState.OutDated)
                rez++;
            if (versionsService.VerifyUserAppVersion("BusinessStartegy v0.1") == VersionState.OutDated)
                rez++;
            if (versionsService.VerifyUserAppVersion("BusinessStartegy v1.0") == VersionState.Actual)
                rez++;
            Assert.AreEqual(rez, 3);
        }
    }
}
