using PortfolioCommon.Data.Entities;

namespace PortfolioCommon.Services.Interfaces
{
    public interface IUserService
    {
        User Signin(string login, string password, string passwordConfirmation, string firstname, string lastname);
        User Login(string login, string password);
        User GetByLogin(string login);
        User GetByFullName(string firstname, string lastname);
    }
}
