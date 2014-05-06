using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using DataRepository.Services.DataBaseService;

namespace StrategyServices.Versions
{
    public class VersionService : IVersionService
    {
        public VersionService()
        {
            _versionsService = new VersionsService();
        }
        public string GetActualVersion()
        {
            return _versionsService.GetActualVersion();
        }
        public VersionState VerifyUserAppVersion(string userAppVersion)
        {
            return _versionsService.VerifyUserAppVersion(userAppVersion);
        }

        private VersionsService _versionsService;
    }
}
