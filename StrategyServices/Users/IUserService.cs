using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;

namespace StrategyServices.Users
{
    [ServiceContract] // Говорим WCF что это интерфейс для запросов сервису
    public interface IUserService
    {
        [OperationContract] // Делегируемый метод.
        RegistrationState Registration(string login, string password, out string sessionCode);

        [OperationContract]
        AuthorizationState Authorization(string login, string password, out string sessionCode);

        [OperationContract]
        UserData GetUser(string login);
        
        [OperationContract] // Делегируемый метод.
        string GetCommandString(int i);
    }

    [DataContract]
    public class UserData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string HashPassword { get; set; }

        [DataMember]
        public string SessionCode { get; set; }
    }

}
