using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StrategyServices.Versions
{
    [ServiceContract]
    public interface IVersionService
    {
        [OperationContract]
        string GetCommandString(int i);
    }
}
