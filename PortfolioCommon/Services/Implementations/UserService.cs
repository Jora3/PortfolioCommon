using PortfolioCommon.Data.Entities;
using PortfolioCommon.Data.Repositories.Interfaces;
using PortfolioCommon.Services.Helpers;
using PortfolioCommon.Services.Interfaces;
using System;

namespace PortfolioCommon.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetByFullName(string firstname, string lastname)
        {
            return _userRepository.ReadOne(u => u.Firstname.ToLower().Equals(firstname) && u.Lastname.ToLower().Equals(lastname));
        }

        public User GetByLogin(string login)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrWhiteSpace(login))
                throw new Exception("L'identifiant de connexion est vide ou n'a pas été renseigné.");
            return _userRepository.ReadOne(u => u.Login.ToLower().Equals(login.ToLower()));
        }

        public User Login(string login, string password)
        {
            var user = GetByLogin(login);
            if (user != null)
            {
                if (user.Password.Equals(UserPasswordHelper.EncryptPassword(password)))
                {
                    if (!user.Active) throw new Exception("Votre compte n'est pas encore activé. Merci de contacter votre administrateur.");
                    return user;
                }
                throw new Exception("Le mot de passe est incorrect.");
            }
            throw new Exception("Aucun utilisateur ne correspond à l'identifiant de connexion renseigné.");
        }

        public User Signin(string login, string password, string passwordConfirmation, string firstname, string lastname)
        {
            if (password != passwordConfirmation)
                throw new Exception("Le mot de passe n'a pas été bien confirmé.");
            var user = GetByLogin(login);
            if (user == null)
            {
                user = GetByFullName(firstname, lastname);
                if (user == null)
                {
                    user = new User
                    {
                        Login = login.Trim(),
                        Password = UserPasswordHelper.EncryptPassword(password),
                        Firstname = firstname,
                        Lastname = lastname
                    };
                    _userRepository.Create(user);
                    return user;
                }
                throw new Exception($"Un utilisateur nommé {firstname} {lastname} existe déjà.");
            }
            throw new Exception("L'identifiant de connexion renseigné est déjà utilisé par un autre utilisateur.");
        }
    }
}
