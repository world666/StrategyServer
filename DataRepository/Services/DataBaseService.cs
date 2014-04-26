using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.DataAccess;
using DataRepository.Models;
using DataRepository.Models.GenericRepository;
using System.Security.Cryptography;
using System.Web.Helpers;

namespace DataRepository.Services
{
    public class DataBaseService
    {
        public void AddNewUser(string login, string hashCode, string sessionCode)
        {
            var users = new Users
            {
                Login = login,
                HashPassword = hashCode,
                SessionCode = sessionCode
            };
            using (var repoUnit = new RepoUnit())
            {
                repoUnit.Users.Save(users);
            }
        }

        public void DeleteUser(string login, string password)
        {
            using (var repoUnit = new RepoUnit())
            {
                var user = repoUnit.Users.FindFirstBy(u => u.Login == login);
                if (user != null)
                {
                    if (Crypto.VerifyHashedPassword(user.HashPassword, password))
                        repoUnit.Users.Delete(user);
                } 
            }
        }

        private bool LoginExist(string login)
        {
            using (var repoUnit = new RepoUnit())
            {
                var user = repoUnit.Users.FindFirstBy(u => u.Login == login);
                if (user != null)
                    return true;
            }
            return false;
        }

        public RegistrationState Registration(string login, string password, out string sessionCode)
        {
            if (LoginExist(login))
            {
                sessionCode = "0";
                return RegistrationState.LoginExist;   
            }
            else
            {
                var hashCode = Crypto.HashPassword(password);
                sessionCode = login + RandomString(10);
                AddNewUser(login, hashCode, sessionCode);
                return RegistrationState.Success;
            }

        }

        public bool AuthorizedUser(string login, string password)
        {
            using (var repoUnit = new RepoUnit())
            {
                var user = repoUnit.Users.FindFirstBy(u => u.Login == login);
                if (user != null)
                {
                    if (Crypto.VerifyHashedPassword(user.HashPassword, password))
                        return true;
                }
            }
            return false;
        }

        private void WriteNewSessionCodeToUser(string login, string sessionCode)
        {
            using (var repoUnit = new RepoUnit())
            {
                var user = repoUnit.Users.FindFirstBy(u => u.Login == login);
                user.SessionCode = sessionCode;
                repoUnit.Users.Edit(user);
            }
        }

        public AuthorizationState Authorization(string login, string password, out string sessionCode)
        {
            if (AuthorizedUser(login, password))
            {
                sessionCode = login + RandomString(10);
                WriteNewSessionCodeToUser(login, sessionCode);
                return AuthorizationState.Success;
            }
            else
            {
                sessionCode = "0";
                return AuthorizationState.WrongLoginOrPassword;
            }
        }

        private static string RandomString(int size)
        {
            string code = null;
            var buf = new byte[size];
            var rand = new RNGCryptoServiceProvider(new CspParameters());
            rand.GetBytes(buf);
            rand.Dispose();
            for (int i = 0; i < size; i++)
            {
                code += buf[i].ToString("D3");
            }
            return code;
        }

    }
}
