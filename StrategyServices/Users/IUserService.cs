using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StrategyServices.Users
{
    [ServiceContract] // Говорим WCF что это интерфейс для запросов сервису
    public interface IUserService
    {
        [OperationContract] // Делегируемый метод.
        string GetCommandString(int i);
    }
}
