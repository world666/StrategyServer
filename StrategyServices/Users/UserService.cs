using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using DataRepository.Services;

namespace StrategyServices.Users
{
    public class UserService : IUserService
    {
        public UserService()
        {
            _dataBaseService = new DataBaseService();
        }
        public RegistrationState Registration(string login, string password, out string sessionCode)
        {
            return _dataBaseService.Registration(login, password, out sessionCode);
        }
        public AuthorizationState Authorization(string login, string password, out string sessionCode)
        {
            return _dataBaseService.Authorization(login, password, out sessionCode);
        }
        public string GetCommandString(int i)
        {
            switch (i)
            {
                case 1:// TODO: Реализация старта выполнения ваших команд
                    return "Начало обработки";

                case 0:// TODO: Реализация остановки выполнения ваших команд
                    return "Привет";

                default:// TODO: Выполнение какой-либо вашей команды
                    return "Получил " + i.ToString();
            }
        }

        private DataBaseService _dataBaseService;
    }
}
