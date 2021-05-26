using System;
using System.Security.Cryptography;
using System.Text;

namespace PortfolioCommon.Services.Helpers
{
    public static class UserPasswordHelper
    {
        public static string EncryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
                throw new Exception("Le mot de passe est vide ou n'a pas été renseigné.");
            return Encoding.UTF8.GetString(SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
    }
}
