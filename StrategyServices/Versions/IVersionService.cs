using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;

namespace StrategyServices.Versions
{
    [ServiceContract]
    public interface IVersionService
    {
        [OperationContract] // Делегируемый метод.
        string GetActualVersion();

        [OperationContract]
        VersionState VerifyUserAppVersion(string userAppVersion);

        [OperationContract]
        string GetCommandString(int i);
    }
}
