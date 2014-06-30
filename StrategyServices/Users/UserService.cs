using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using DataRepository.Services.DataBaseService;

namespace StrategyServices.Users
{
    public class UserService : IUserService
    {
        public UserService()
        {
            _usersService = new UsersService();
        }
        public RegistrationState Registration(string login, string password, out string sessionCode)
        {
            return _usersService.Registration(login, password, out sessionCode);
        }
        public AuthorizationState Authorization(string login, string password, out string sessionCode)
        {
            return _usersService.Authorization(login, password, out sessionCode);
        }
        public UserData GetUser(string login)
        {
            var user = _usersService.GetUser(login);
            if (user == null)
                return null;
            var retUser = new UserData
            {
                Id = user.Id,
                Login = user.Login,
                HashPassword = user.HashPassword,
                SessionCode = user.SessionCode
            };
            return retUser;
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
        
        private UsersService _usersService;
    }
}
