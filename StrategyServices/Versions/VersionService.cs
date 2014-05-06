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

        private VersionsService _versionsService;
    }
}
