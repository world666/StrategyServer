using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StrategyServices.Languages
{
    [ServiceContract]
    public interface ILanguageService
    {
        [OperationContract]
        List<string> GetLanguages();

        [OperationContract]
        int GetLanguagesCount();
    }
}
