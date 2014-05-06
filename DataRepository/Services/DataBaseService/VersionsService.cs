using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using DataRepository.Models.GenericRepository;

namespace DataRepository.Services.DataBaseService
{
    public class VersionsService
    {
        public string GetActualVersion()
        {
            string actualVersion = "";
            using (var repoUnit = new RepoUnit())
            {
                var version = repoUnit.Versions.LastRecord(v => v.Id == v.Id);
                if (version != null)
                    actualVersion = version.VersionName;

            }
            return actualVersion;
        }

        public VersionState VerifyUserAppVersion(string userAppVersion)
        {
            if (GetActualVersion() == userAppVersion)
                return VersionState.Actual;
            return VersionState.OutDated;
        }
    }
}
